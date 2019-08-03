using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class SurveyTemplateDetail : AdminBasePage
{
    private CommonAdministration _CommonAdministrationObject = null;
    public string fields = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        _CommonAdministrationObject = new CommonAdministration();
        DropDownGlobalCode.DataSource = _CommonAdministrationObject.GetGlobalCodeCategories(-1);
        DropDownGlobalCode.DataTextField = "Category";
        DropDownGlobalCode.DataValueField = "Category";
        DropDownGlobalCode.DataBind();

        BindControls();
    }

    public void BindControls()
    {
        string controlName = string.Empty;
        _CommonAdministrationObject = new CommonAdministration();
        DataTable UserDefinedField = _CommonAdministrationObject.GetGlobalCodes(-1, -1, "UDFFIELDDATATYPE", false);
        foreach (DataRow row in UserDefinedField.Rows)
        {
            switch (row["CodeName"].ToString())
            {
                case "Varchar":
                    {
                        controlName = "Text Box";
                        break;
                    }
                case "Text":
                    {
                        controlName = "Text Area";
                        break;
                    }
                case "Integer":
                    {
                        controlName = "Integer";
                        break;
                    }
                case "Date":
                    {
                        controlName = "Date Time";
                        break;
                    }
                case "Money":
                    {
                        controlName = "Money / Decimal";
                        break;
                    }
                case "GlobalCode":
                    {
                        controlName = "Global Code";
                        break;
                    }
            }
            fields += "<tr><td><a href='javascript:void(0);' id=\"FormControl-" + row["CodeName"].ToString() + "\" code-value='" + row["GlobalCodeId"].ToString() + "' data-type='" + row["CodeName"].ToString() + "'>" + controlName + "</a></td></tr>";
        }

    }
}
