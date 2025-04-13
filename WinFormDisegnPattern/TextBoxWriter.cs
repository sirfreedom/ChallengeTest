using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class TextBoxWriter : TextWriter
{
    private TextBox control;
    private StringBuilder bufferStringBuilder;

    public TextBoxWriter(TextBox txtConsole)
    {
        control = txtConsole;
        control.HandleCreated += ControlHandleCreated;
    }

    public override void Write(string format)
    {
        if (control.IsHandleCreated)
            AppendText(format);
        else
            BufferText(format);
    }
    public override void WriteLine(string format)
    {
        Write(format + "\r\n");
    }

    private void BufferText(string format)
    {
        if (bufferStringBuilder == null)
        {
            bufferStringBuilder = new StringBuilder();
        }
        bufferStringBuilder.Append(format);
    }

    private void AppendText(string format)
    {
        if (bufferStringBuilder != null)
        {
            control.AppendText(bufferStringBuilder.ToString());
            bufferStringBuilder = null;
        }
        control.AppendText(format);
    }

    void ControlHandleCreated(object sender, EventArgs e)
    {
        if (bufferStringBuilder != null)
        {
            control.AppendText(bufferStringBuilder.ToString());
            bufferStringBuilder = null;
        }
    }

    public override Encoding Encoding
    {
        get
        {
            //throw new NotImplementedException(); 
            return Encoding.Default;
        }
    }
}