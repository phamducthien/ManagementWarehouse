using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WH.GUI.Properties;

namespace WH.GUI
{
    internal class AnimateMsgBox
    {
        public Size FormSize;
        public MsgBox.AnimateStyle Style;

        public AnimateMsgBox(Size formSize, MsgBox.AnimateStyle style)
        {
            FormSize = formSize;
            Style = style;
        }
    }

    public enum IconMessageBox
    {
        Information,
        Warning,
        Error,
        Question
    }

    public class MsgBox : Form
    {
        public enum AnimateStyle
        {
            SlideDown = 1,
            FadeIn = 2,
            ZoomIn = 3
        }

        public enum Buttons
        {
            AbortRetryIgnore = 1,
            Ok = 2,
            OkCancel = 3,
            RetryCancel = 4,
            YesNo = 5,
            YesNoCancel = 6
        }

        public enum IconMsgBox
        {
            Application = 1,
            Exclamation = 2,
            Error = 3,
            Warning = 4,
            Info = 5,
            Question = 6,
            Shield = 7,
            Search = 8
        }

        private const int CsDropshadow = 0x00020000;
        private static MsgBox _msgBox;
        private static DialogResult _buttonResult;
        private static Timer _timer;
        private static Point _lastMousePos;
        private readonly List<Button> _buttonCollection = new List<Button>();
        private readonly FlowLayoutPanel _flpButtons = new FlowLayoutPanel();
        private readonly Label _lblMessage;
        private readonly Label _lblTitle;
        private readonly PictureBox _picIcon = new PictureBox();
        private readonly Panel _plFooter = new Panel();
        private readonly Panel _plHeader = new Panel();
        private readonly Panel _plIcon = new Panel();

        private MsgBox()
        {
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(45, 45, 48);
            StartPosition = FormStartPosition.CenterScreen;
            Padding = new Padding(3);
            Width = 400;

            _lblTitle = new Label
            {
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18),
                Dock = DockStyle.Top,
                Height = 50
            };

            _lblMessage = new Label {ForeColor = Color.White, Font = new Font("Segoe UI", 10), Dock = DockStyle.Fill};

            _flpButtons.FlowDirection = FlowDirection.RightToLeft;
            _flpButtons.Dock = DockStyle.Fill;

            _plHeader.Dock = DockStyle.Fill;
            _plHeader.Padding = new Padding(20);
            _plHeader.Controls.Add(_lblMessage);
            _plHeader.Controls.Add(_lblTitle);

            _plFooter.Dock = DockStyle.Bottom;
            _plFooter.Padding = new Padding(20);
            _plFooter.BackColor = Color.FromArgb(37, 37, 38);
            _plFooter.Height = 80;
            _plFooter.Controls.Add(_flpButtons);

            _picIcon.Width = 32;
            _picIcon.Height = 32;
            _picIcon.Location = new Point(30, 50);

            _plIcon.Dock = DockStyle.Left;
            _plIcon.Padding = new Padding(20);
            _plIcon.Width = 70;
            _plIcon.Controls.Add(_picIcon);

            var controlCollection = new List<Control>
            {
                this,
                _lblTitle,
                _lblMessage,
                _flpButtons,
                _plHeader,
                _plFooter,
                _plIcon,
                _picIcon
            };

            foreach (var control in controlCollection)
            {
                control.MouseDown += MsgBox_MouseDown;
                control.MouseMove += MsgBox_MouseMove;
            }

            Controls.Add(_plHeader);
            Controls.Add(_plIcon);
            Controls.Add(_plFooter);
        }

        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);

        private static void MsgBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _lastMousePos = new Point(e.X, e.Y);
        }

        private static void MsgBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _msgBox.Left += e.X - _lastMousePos.X;
                _msgBox.Top += e.Y - _lastMousePos.Y;
            }
        }

        public static DialogResult Show(string message)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;

            InitButtons(Buttons.Ok);

            _msgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox._lblTitle.Text = title;
            _msgBox.Size = MessageSize(message);

            InitButtons(Buttons.Ok);

            _msgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox._lblTitle.Text = title;
            _msgBox._plIcon.Hide();

            InitButtons(buttons);

            _msgBox.Size = MessageSize(message);
            _msgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, IconMsgBox icon)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox._lblTitle.Text = title;

            InitButtons(buttons);
            InitIcon(icon);

            _msgBox.Size = MessageSize(message);
            _msgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, IconMsgBox icon,
            AnimateStyle style)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox._lblTitle.Text = title;
            _msgBox.Height = 0;

            InitButtons(buttons);
            InitIcon(icon);

            _timer = new Timer();
            var formSize = MessageSize(message);

            switch (style)
            {
                case AnimateStyle.SlideDown:
                    _msgBox.Size = new Size(formSize.Width, 0);
                    _timer.Interval = 1;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case AnimateStyle.FadeIn:
                    _msgBox.Size = formSize;
                    _msgBox.Opacity = 0;
                    _timer.Interval = 20;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case AnimateStyle.ZoomIn:
                    _msgBox.Size = new Size(formSize.Width + 100, formSize.Height + 100);
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    _timer.Interval = 1;
                    break;
            }

            _timer.Tick += timer_Tick;
            _timer.Start();

            _msgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            var timer = (Timer) sender;
            var animate = (AnimateMsgBox) timer.Tag;

            switch (animate.Style)
            {
                case AnimateStyle.SlideDown:
                    if (_msgBox.Height < animate.FormSize.Height)
                    {
                        _msgBox.Height += 17;
                        _msgBox.Invalidate();
                    }
                    else
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }

                    break;

                case AnimateStyle.FadeIn:
                    if (_msgBox.Opacity < 1)
                    {
                        _msgBox.Opacity += 0.1;
                        _msgBox.Invalidate();
                    }
                    else
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }

                    break;

                case AnimateStyle.ZoomIn:
                    if (_msgBox.Width > animate.FormSize.Width)
                    {
                        _msgBox.Width -= 17;
                        _msgBox.Invalidate();
                    }

                    if (_msgBox.Height > animate.FormSize.Height)
                    {
                        _msgBox.Height -= 17;
                        _msgBox.Invalidate();
                    }

                    break;
            }
        }

        private static void InitButtons(Buttons buttons)
        {
            switch (buttons)
            {
                case Buttons.AbortRetryIgnore:
                    _msgBox.InitAbortRetryIgnoreButtons();
                    break;

                case Buttons.Ok:
                    _msgBox.InitOkButton();
                    break;

                case Buttons.OkCancel:
                    _msgBox.InitOkCancelButtons();
                    break;

                case Buttons.RetryCancel:
                    _msgBox.InitRetryCancelButtons();
                    break;

                case Buttons.YesNo:
                    _msgBox.InitYesNoButtons();
                    break;

                case Buttons.YesNoCancel:
                    _msgBox.InitYesNoCancelButtons();
                    break;
            }

            foreach (var btn in _msgBox._buttonCollection)
            {
                btn.ForeColor = Color.FromArgb(170, 170, 170);
                btn.Font = new Font("Segoe UI", 8);
                btn.Padding = new Padding(3);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Height = 30;
                btn.FlatAppearance.BorderColor = Color.FromArgb(99, 99, 98);

                _msgBox._flpButtons.Controls.Add(btn);
            }
        }

        private static void InitIcon(IconMsgBox icon)
        {
            switch (icon)
            {
                case IconMsgBox.Application:
                    _msgBox._picIcon.Image = Resources.Application.ToBitmap();
                    break;

                case IconMsgBox.Exclamation:
                    _msgBox._picIcon.Image = Resources.Exclamation.ToBitmap();
                    break;

                case IconMsgBox.Error:
                    _msgBox._picIcon.Image = Resources.Error.ToBitmap();
                    break;

                case IconMsgBox.Info:
                    _msgBox._picIcon.Image = Resources.Info.ToBitmap();
                    break;

                case IconMsgBox.Question:
                    _msgBox._picIcon.Image = Resources.Question.ToBitmap();
                    break;

                case IconMsgBox.Shield:
                    _msgBox._picIcon.Image = Resources.Shield.ToBitmap();
                    break;

                case IconMsgBox.Warning:
                    _msgBox._picIcon.Image = Resources.Warning.ToBitmap();
                    break;
            }
        }

        private void InitAbortRetryIgnoreButtons()
        {
            var btnAbort = new Button {Text = @"Ngưng chạy"};
            btnAbort.Click += ButtonClick;

            var btnRetry = new Button {Text = @"Thử Lại"};
            btnRetry.Click += ButtonClick;

            var btnIgnore = new Button {Text = @"Bỏ Qua"};
            btnIgnore.Click += ButtonClick;

            _buttonCollection.Add(btnAbort);
            _buttonCollection.Add(btnRetry);
            _buttonCollection.Add(btnIgnore);
        }

        private void InitOkButton()
        {
            var btnOk = new Button {Text = @"Xác Nhận"};
            btnOk.Click += ButtonClick;

            _buttonCollection.Add(btnOk);
        }

        private void InitOkCancelButtons()
        {
            var btnOk = new Button {Text = @"Đồng Ý"};
            btnOk.Click += ButtonClick;

            var btnCancel = new Button {Text = @"Huỷ Bỏ"};
            btnCancel.Click += ButtonClick;

            _buttonCollection.Add(btnOk);
            _buttonCollection.Add(btnCancel);
        }

        private void InitRetryCancelButtons()
        {
            var btnRetry = new Button {Text = @"Thử Lại"};
            btnRetry.Click += ButtonClick;

            var btnCancel = new Button {Text = @"Huỷ Bỏ"};
            btnCancel.Click += ButtonClick;

            _buttonCollection.Add(btnRetry);
            _buttonCollection.Add(btnCancel);
        }

        private void InitYesNoButtons()
        {
            var btnYes = new Button {Text = @"Đồng Ý"};
            btnYes.Click += ButtonClick;

            var btnNo = new Button {Text = @"Bỏ"};
            btnNo.Click += ButtonClick;

            _buttonCollection.Add(btnYes);
            _buttonCollection.Add(btnNo);
        }

        private void InitYesNoCancelButtons()
        {
            var btnYes = new Button {Text = @"Ngưng chạy"};
            btnYes.Click += ButtonClick;

            var btnNo = new Button {Text = @"Thử Lại"};
            btnNo.Click += ButtonClick;

            var btnCancel = new Button {Text = @"Huỷ Bỏ"};
            btnCancel.Click += ButtonClick;

            _buttonCollection.Add(btnYes);
            _buttonCollection.Add(btnNo);
            _buttonCollection.Add(btnCancel);
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            var btn = (Button) sender;

            switch (btn.Text)
            {
                case "Ngưng chạy":
                    _buttonResult = DialogResult.Abort;
                    break;

                case "Thử Lại":
                    _buttonResult = DialogResult.Retry;
                    break;

                case "Bỏ Qua":
                    _buttonResult = DialogResult.Ignore;
                    break;

                case "Xác Nhận":
                    _buttonResult = DialogResult.OK;
                    break;

                case "Huỷ Bỏ":
                    _buttonResult = DialogResult.Cancel;
                    break;

                case "Đồng Ý":
                    _buttonResult = DialogResult.Yes;
                    break;

                case "Bỏ":
                    _buttonResult = DialogResult.No;
                    break;
            }

            _msgBox.Dispose();
        }

        private static Size MessageSize(string message)
        {
            var g = _msgBox.CreateGraphics();
            var width = 350;
            var height = 230;

            var size = g.MeasureString(message, new Font("Segoe UI", 10));

            if (message?.Length < 150)
            {
                if ((int) size.Width > 350)
                    width = (int) size.Width;
            }
            else
            {
                var groups = (from Match m in Regex.Matches(message ?? "", ".{1,180}") select m.Value).ToArray();
                var lines = groups.Length + 1;
                width = 700;
                height += (int) (size.Height + 10) * lines;
            }

            return new Size(width, height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            var rect = new Rectangle(new Point(0, 0), new Size(Width - 1, Height - 1));
            var pen = new Pen(Color.FromArgb(0, 151, 251));

            g.DrawRectangle(pen, rect);
        }
    }
}