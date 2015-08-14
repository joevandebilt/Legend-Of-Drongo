/*
 * Credit where it's due, I stole all this code from Stack overflow
 * http://stackoverflow.com/questions/4024798/trying-to-use-the-c-sharp-spellcheck-class
 *
 * I may be a theif but at least I'm honest!
 */

using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;

[Designer(typeof(ControlDesigner))]
//[DesignerSerializer("System.Windows.Forms.Design.ControlCodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
class SpellBox : ElementHost
{
    public SpellBox()
    {
        box = new System.Windows.Controls.TextBox();
        base.Child = box;
        box.TextChanged += (s, e) => OnTextChanged(EventArgs.Empty);
        box.SpellCheck.IsEnabled = true;
        box.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        this.Size = new System.Drawing.Size(100, 20);

        //On Double clikc run this method
        this.box.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(DoubleMouseClick);
    }

    public override string Text
    {
        get { return box.Text; }
        set { box.Text = value; }
    }
    [DefaultValue(false)]
    public bool Multiline
    {
        get { return box.AcceptsReturn; }
        set { box.AcceptsReturn = value; }
    }
    [DefaultValue(false)]
    public bool WordWrap
    {
        get { return box.TextWrapping != TextWrapping.NoWrap; }
        set { box.TextWrapping = value ? TextWrapping.Wrap : TextWrapping.NoWrap; }
    }

    [DefaultValue(false)]
    public bool ReadOnly
    {
        get { return box.IsReadOnly; }
        set {box.IsReadOnly = value; }
    }
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new System.Windows.UIElement Child
    {
        get { return base.Child; }
        set { /* Do nothing to solve a problem with the serializer !! */ }
    }

    private void DoubleMouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        //If one has been set for this instance, trigger the double click handler
        if (MouseDoubleClickHandler != null) MouseDoubleClickHandler(null, new System.Windows.Forms.MouseEventArgs(MouseButtons.None,0,0,0,0));
    }

    private System.Windows.Controls.TextBox box;

    //Provide a public event for Windows forms to bind onto
    public MouseEventHandler MouseDoubleClickHandler;
}