using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using _1RM.Model.Protocol;
using Shawn.Utils;

namespace _1RM.View.Editor.Forms
{
    public partial class RdpFormView : UserControl
    {
        private CompletionWindow? _completionWindow;

        private void ShowCompletionWindow(IEnumerable<string> completions, TextArea textArea)
        {
            _completionWindow?.Close();
            var enumerable = completions as string[] ?? completions.ToArray();
            if (enumerable?.Any() != true) return;

            _completionWindow = new CompletionWindow(textArea)
            {
                CloseWhenCaretAtBeginning = true,
                CloseAutomatically = true,
                BorderThickness = new System.Windows.Thickness(0),
                Background = (App.ResourceDictionary?["BackgroundBrush"] as Brush) ?? Brushes.White,
                Foreground = (App.ResourceDictionary?["BackgroundTextBrush"] as Brush) ?? Brushes.Black,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.None,
                Width = 500,
            };

            _completionWindow.KeyDown += (sender, e) =>
            {
                if (e.Key == Key.Escape)
                {
                    _completionWindow.Close();
                    e.Handled = true;
                }
            };

            var completionData = _completionWindow.CompletionList.CompletionData;
            foreach (var str in enumerable)
            {
                completionData.Add(new RdpFileSettingCompletionData(str));
            }
            _completionWindow.Show();
            if (enumerable.Count() == 1)
                _completionWindow.CompletionList.SelectItem(enumerable.First());
            _completionWindow.Closed += (o, args) => _completionWindow = null;
        }

        public RdpFormView()
        {
            InitializeComponent();
        }

        private void ButtonShowMonitorsNum_OnClick(object sender, RoutedEventArgs e)
        {
            var p = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            p.Start();
            p.StandardInput.WriteLine($"mstsc /l");
            p.StandardInput.WriteLine("exit");
        }

        private void ButtonPreviewRdpFile_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not RdpFormViewModel viewModel) return;
            var rdp = viewModel.New;
            var tmp = Path.GetTempPath();
            var rdpFileName = $"{rdp.DisplayName}_{rdp.Port}_{MD5Helper.GetMd5Hash16BitString(rdp.UserName)}";
            var invalid = new string(Path.GetInvalidFileNameChars()) +
                          new string(Path.GetInvalidPathChars());
            rdpFileName = invalid.Aggregate(rdpFileName, (current, c) => current.Replace(c.ToString(), ""));
            var rdpFile = Path.Combine(tmp, rdpFileName + ".rdp");

            // write a .rdp file for mstsc.exe
            File.WriteAllText(rdpFile, rdp.ToRdpConfig().ToString());
            var p = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            p.Start();
            p.StandardInput.WriteLine($"notepad " + rdpFile);
            p.StandardInput.WriteLine("exit");
        }
    }

    public class RdpFileSettingCompletionData : ICompletionData
    {
        public RdpFileSettingCompletionData(string text)
        {
            Text = text;
        }

        public ImageSource? Image => null;

        public string Text { get; }

        public object Content => Text;

        public object Description => this.Text;

        public double Priority { get; }

        public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
        {
            int offset = textArea.Caret.Offset;
            var currentLine = textArea.Document.GetLineByOffset(offset);
            textArea.Document.Replace(completionSegment, Text.Substring(offset - currentLine.Offset));
        }

        public static readonly string[] Settings =
        {
            "full address:s:",
            "alternate full address:s:",
            "username:s:",
            "domain:s:",
            "gatewayhostname:s:",
            "gatewaycredentialssource:i:",
            "gatewayprofileusagemethod:i:",
            "gatewayusagemethod:i:",
            "promptcredentialonce:i:",
            "authentication level:i:",
            "enablecredsspsupport:i:",
            "disableconnectionsharing:i:",
            "alternate shell:s:",
            "autoreconnection enabled:i:",
            "screen mode id:i:",
            "use multimon:i:",
            "maximizetocurrentdisplays:i:",
            "desktopwidth:i:",
            "desktopheight:i:",
            "session bpp:i:",
            "winposstr:s:",
            "compression:i:",
            "keyboardhook:i:",
            "audiocapturemode:i:",
            "videoplaybackmode:i:",
            "connection type:i:",
            "networkautodetect:i:",
            "bandwidthautodetect:i:",
            "displayconnectionbar:i:",
            "pinconnectionbar:i:",
            "drivestoredirect:s:",
            "devicestoredirect:s:",
            "redirectdrives:i:",
            "redirectprinters:i:",
            "redirectcomports:i:",
            "redirectsmartcards:i:",
            "redirectclipboard:i:",
            "redirectposdevices:i:",
            "redirectdirectx:i:",
            "disableprinterredirection:i:",
            "disableclipboardredirection:i:",
            "disablecomportsredirection:i:",
            "drivestoredirect:s:",
            "redirectdrives:i:",
            "redirectprinters:i:",
            "redirectcomports:i:",
            "redirectsmartcards:i:",
            "redirectclipboard:i:",
            "redirectposdevices:i:",
            "redirectdirectx:i:",
            "disableprinterredirection:i:",
            "disableclipboardredirection:i:",
            "disablecomportsredirection:i:",
            "audiomode:i:",
            "videoplaybackmode:i:",
            "audiocapturemode:i:"
        };
    }
}