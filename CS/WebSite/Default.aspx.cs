using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    /* Init */

    protected void lnkEdit_Init(object sender, EventArgs e) {
        ASPxHyperLink lnk = sender as ASPxHyperLink;
        GridViewDataItemTemplateContainer container = lnk.NamingContainer as GridViewDataItemTemplateContainer;

        lnk.ClientInstanceName = String.Format("lnkEdit{0}", container.VisibleIndex);
        lnk.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.StartEditRow ({1}); }}",
            (String.IsNullOrEmpty(container.Grid.ClientInstanceName) ? container.Grid.ClientID : container.Grid.ClientInstanceName),
            container.VisibleIndex);
    }

    protected void lnkNew_Init(object sender, EventArgs e) {
        ASPxHyperLink lnk = sender as ASPxHyperLink;
        GridViewDataItemTemplateContainer container = lnk.NamingContainer as GridViewDataItemTemplateContainer;

        lnk.ClientInstanceName = String.Format("lnkNew{0}", container.VisibleIndex);
        lnk.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.AddNewRow (); }}",
            (String.IsNullOrEmpty(container.Grid.ClientInstanceName) ? container.Grid.ClientID : container.Grid.ClientInstanceName));
    }

    protected void lnkDelete_Init(object sender, EventArgs e) {
        ASPxHyperLink lnk = sender as ASPxHyperLink;
        GridViewDataItemTemplateContainer container = lnk.NamingContainer as GridViewDataItemTemplateContainer;

        lnk.ClientInstanceName = String.Format("lnkDelete{0}", container.VisibleIndex);
        lnk.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.DeleteRow ({1}); }}",
            (String.IsNullOrEmpty(container.Grid.ClientInstanceName) ? container.Grid.ClientID : container.Grid.ClientInstanceName),
            container.VisibleIndex);
    }

    /* Load */

    protected void lnkEdit_Load(object sender, EventArgs e) {
        ASPxHyperLink lnk = sender as ASPxHyperLink;

        lnk.ClientEnabled = !chkEdit.Checked;
    }

    protected void lnkNew_Load(object sender, EventArgs e) {
        ASPxHyperLink lnk = sender as ASPxHyperLink;

        lnk.ClientEnabled = !chkNew.Checked;
    }

    protected void lnkDelete_Load(object sender, EventArgs e) {
        ASPxHyperLink lnk = sender as ASPxHyperLink;

        lnk.ClientEnabled = !chkDelete.Checked;
    }
}
