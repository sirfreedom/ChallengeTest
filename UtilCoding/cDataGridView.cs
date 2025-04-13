using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public partial class cDataGridView : DataGridView
{

    #region Metodos Prederterminados

    [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), CategoryAttribute("DataBindings"), DescriptionAttribute("")]
    public new bool AllowUserToAddRows
    {
        get
        {
            return base.AllowUserToAddRows;
        }
        set
        {
            base.AllowUserToAddRows = value;
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }
    }

    [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), CategoryAttribute("DataBindings"), DescriptionAttribute("")]
    public new bool AllowUserToDeleteRows
    {
        get
        {
            return base.AllowUserToDeleteRows;
        }
        set
        {
            base.AllowUserToDeleteRows = value;
            if (this.DesignMode)
                this.Invalidate();
        }
    }

    [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), CategoryAttribute("DataBindings"), DescriptionAttribute("")]
    public new bool RowHeadersVisible
    {
        get
        {
            return base.RowHeadersVisible;
        }
        set
        {
            base.RowHeadersVisible = value;
            if (this.DesignMode)
                this.Invalidate();
        }
    }

    [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), CategoryAttribute("DataBindings"), DescriptionAttribute("")]
    public new bool MultiSelect
    {
        get
        {
            return base.MultiSelect;
        }
        set
        {
            base.MultiSelect = value;
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }
    }

    [System.ComponentModel.DefaultValueAttribute(typeof(bool), "false"), CategoryAttribute("DataBindings"), DescriptionAttribute("")]
    public new bool AllowUserToResizeRows
    {
        get
        {
            return base.AllowUserToResizeRows;
        }
        set
        {
            base.AllowUserToResizeRows = value;
            if (this.DesignMode)
                this.Invalidate();
        }
    }

    public int VerticalScrollBarValue
    {
        get { return this.VerticalScrollBar.Value; }
            set { 
            if (this.VerticalScrollBar.Value < this.VerticalScrollBar.Maximum)
                this.VerticalScrollBar.Value = value;
        }
    }

    public void PrepararGrilla()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();

        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.LightGray; 
        dataGridViewCellStyle1.Font = new Font("Verdana", 10, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.MidnightBlue;
        dataGridViewCellStyle1.SelectionBackColor = Color.PapayaWhip;
        dataGridViewCellStyle1.SelectionForeColor = Color.MidnightBlue;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;

        this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        this.DefaultCellStyle = dataGridViewCellStyle1;
        this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        this.RowsDefaultCellStyle = dataGridViewCellStyle1;
        this.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.RowHeadersWidth = 22;
        this.RowTemplate.Height = 22;
        this.RowTemplate.Resizable = DataGridViewTriState.False;
        this.BackgroundColor = Color.WhiteSmoke;
        this.ColumnHeadersHeight = 30;
        this.AllowUserToAddRows = false;
        this.MultiSelect = true;
        this.RowHeadersVisible = true;
        this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        this.Anchor = AnchorStyles.None;
        this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        this.ShowCellErrors = false;
        this.ShowCellToolTips = false;
        this.ShowEditingIcon = false;
        this.ShowRowErrors = false;
        this.AllowUserToDeleteRows = false;
        this.AllowUserToOrderColumns = false;
        this.AllowUserToResizeRows = false;
        this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    public void CleanRows()
    {
    }

    public cDataGridView()
    {
        InitializeComponent();
        this.CellClick += new DataGridViewCellEventHandler(cDataGridView_CellClick);
    }

    public void cDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
     
    }

    #endregion

    #region Seleccion de registros

    public void SeleccionarTodosLosRegistros(string nombreColumChk, bool seleccionar)
    {
        int rs = 0;
        try
        {
            while (rs < this.RowCount)
            {
                this.Rows[rs].Cells[nombreColumChk].Value = seleccionar;
                rs = rs + 1;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SelectRows(string nombreColumChk, string nombrecolumnaid, List<string> listIds)
    {
        int rs = 0;
        try
        {
            while (rs < this.RowCount)
            {
                foreach (string s in listIds)
                {
                    if (this.Rows[rs].Cells[nombrecolumnaid].Value.ToString() == s)
                    {
                        this.Rows[rs].Cells[nombreColumChk].Value = true;
                        break;
                    }
                }
                rs = rs + 1;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SelectRows(string nombreColumChkgrilla, string nombrecolumnaidgrilla, DataTable dtids, string nombrecolumnaidtabla)
    {
        int rs = 0;
        try
        {
            while (rs < this.RowCount)
            {
                foreach (DataRow r in dtids.Rows)
                {
                    if (this.Rows[rs].Cells[nombrecolumnaidgrilla].Value.ToString() == r[nombrecolumnaidtabla].ToString())
                    {
                        this.Rows[rs].Cells[nombreColumChkgrilla].Value = true;
                        break;
                    }
                }
                rs = rs + 1;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int GetCantidadDeRegistros(string nombreColum, string valorColum)
    {
        int cantidad = -1, rs = 0;
        try
        {
            if (this.Rows.Count > 0)
            {
                cantidad = 0;
                for (rs = 0; rs < this.RowCount; rs++)
                {
                    if (nombreColum != null && nombreColum.Trim().Length > 0
                        && this.Rows[rs].Cells[nombreColum].Value != null
                        && this.Rows[rs].Cells[nombreColum].Value.ToString().Trim().ToUpper() == valorColum.Trim().ToUpper())
                    {
                        cantidad = cantidad + 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return cantidad;
    }

    public List<string> GetSeleccionados(string nombreColumnaChk, string nombreColumnaPK)
    {
        List<string> l = new List<string>();
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        try
        {
            foreach (DataGridViewRow g in this.Rows)
            {
                DataGridViewCheckBoxCell chkCol = new DataGridViewCheckBoxCell();
                DataGridViewTextBoxCell txtDatos = new DataGridViewTextBoxCell();
                chkCol = (DataGridViewCheckBoxCell)g.Cells[nombreColumnaChk];
                txtDatos = (DataGridViewTextBoxCell)g.Cells[nombreColumnaPK];

                if (chkCol.Value != null)
                {
                    if (g.Cells[nombreColumnaChk].Value != null)
                    {
                        if (g.Cells[nombreColumnaChk].Value.ToString() != string.Empty || g.Cells[nombreColumnaChk].Value.ToString() != "0")
                        {
                            if (g.Cells[nombreColumnaChk].Value.ToString() == "1")
                            {
                                if (txtDatos.Value != null || txtDatos.Value.ToString() != string.Empty)
                                {
                                    l.Add(txtDatos.Value.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return l;
    }

    public DataTable GetGrilla(string nombreColumnaChk, string nombreColumnaPK)
    {
        DataTable dt = new DataTable();
        dt = ((DataTable)this.DataSource).Copy();
        List<string> l = new List<string>();
        l = this.GetSeleccionados(nombreColumnaChk, nombreColumnaPK);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            bool bExiste = false;

            foreach (string s in l)
            {
                if (dt.Rows[i][nombreColumnaPK].ToString().Contains(s))
                {
                    bExiste = true;
                    break;
                }
            }

            if (bExiste == false)
            {
                dt.Rows[i].Delete();
                dt.AcceptChanges();
                i--;
            }
        }
        return dt;
    }

    public List<string> GetSel(string nombreColumChk, string NombreColumnaPk)
    {
        List<string> lItems = new List<string>();
        try
        {
            foreach (DataGridViewRow r in this.Rows)
            {
                if (bool.Parse(r.Cells[nombreColumChk].Value.ToString()) == true)
                {
                    lItems.Add(r.Cells[NombreColumnaPk].Value.ToString());
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        return lItems;
    }

    public int SetUbicarRegistro(string NombreColumna, string PalabraBuscar)
    {
        int i = 0;
        try
        {
            foreach (DataGridViewRow r in this.Rows)
            {
                if (r.Cells[NombreColumna].Value != null)
                {
                    if (r.Cells[NombreColumna].Value.ToString().Contains(PalabraBuscar))
                    {
                        r.Selected = true;
                        i++;
                        break;
                    }
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        return i;
    }

    public int SeleccionarTodosLosRegistros(string nombreColumChk, bool seleccionar, string ColumnaCondicion, string Condicion, bool NegarCondicion = false)
    {
        int iSeleccionar = 0;
        try
        {
            foreach (DataGridViewRow r in this.Rows)
            {
                if (r.Cells[ColumnaCondicion].Value.ToString().Trim().Contains(Condicion) && NegarCondicion == false)
                {
                    iSeleccionar = iSeleccionar + 1;
                    r.Cells[nombreColumChk].Value = seleccionar;
                }

                if (r.Cells[ColumnaCondicion].Value.ToString().Trim().Contains(Condicion) == false && NegarCondicion == true)
                {
                    iSeleccionar = iSeleccionar + 1;
                    r.Cells[nombreColumChk].Value = seleccionar;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        return iSeleccionar;
    }

    public string[] GetReport()
    {
        DataTable dt;
        StringBuilder sb = new StringBuilder();
        List<string> lResult = new List<string>();
        string[] lReturn;
        try
        {
            dt = (DataTable)this.DataSource;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.AppendLine();

            foreach (DataRow row in dt.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                sb.AppendLine(string.Join(",", fields));
            }

            lReturn = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return lReturn;
    }

    #endregion




    public int CountRows
    {
        get
        {
            DataTable dt;
            if (this.DataSource == null)
            {
                return 0;
            }
            dt = (DataTable)this.DataSource;
            return dt.Rows.Count;
        }
    }



}

