<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to enable/disable command buttons on the client side</title>

    <script type="text/javascript">
        function OnEditCheckedChanged (s, e) {
            var start = grid.GetTopVisibleIndex ();
            var end = grid.GetVisibleRowsOnPage () + start;
            
            for (var i = start; i < end; i++)
                eval("lnkEdit" + i.toString()).SetEnabled(!s.GetChecked());
        }

        function OnNewCheckedChanged (s, e) {
            var start = grid.GetTopVisibleIndex ();
            var end = grid.GetVisibleRowsOnPage () + start;
            
            for (var i = start; i < end; i++)
                eval("lnkNew" + i.toString()).SetEnabled(!s.GetChecked());
        }
        
        function OnDeleteCheckedChanged (s, e) {
            var start = grid.GetTopVisibleIndex ();
            var end = grid.GetVisibleRowsOnPage () + start;
            
            for (var i = start; i < end; i++)
                eval("lnkDelete" + i.toString()).SetEnabled(!s.GetChecked());
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="border: solid 1px black; float: left; padding: 0px 4px 0px 4px;">
                <b>Enable/Disable</b>
                <dx:ASPxCheckBox ID="chkEdit" runat="server" Text="Edit" Checked="true">
                    <ClientSideEvents CheckedChanged="OnEditCheckedChanged" />
                </dx:ASPxCheckBox>
                <dx:ASPxCheckBox ID="chkNew" runat="server" Text="New">
                    <ClientSideEvents CheckedChanged="OnNewCheckedChanged" />
                </dx:ASPxCheckBox>
                <dx:ASPxCheckBox ID="chkDelete" runat="server" Text="Delete">
                    <ClientSideEvents CheckedChanged="OnDeleteCheckedChanged" />
                </dx:ASPxCheckBox>
            </div>
            <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="sds"
                KeyFieldName="ProductID" ClientInstanceName="grid">
                <Columns>
                    <dx:GridViewDataTextColumn VisibleIndex="0">
                        <DataItemTemplate>
                            <dx:ASPxHyperLink ID="lnkEdit" runat="server" Text="Edit" NavigateUrl="javascript:void(0);"
                                OnInit="lnkEdit_Init" OnLoad="lnkEdit_Load">
                                <DisabledStyle ForeColor="gray" />
                            </dx:ASPxHyperLink>
                            <dx:ASPxHyperLink ID="lnkNew" runat="server" Text="New" NavigateUrl="javascript:void(0);"
                                OnInit="lnkNew_Init" OnLoad="lnkNew_Load">
                                <DisabledStyle ForeColor="gray" />
                            </dx:ASPxHyperLink>
                            <dx:ASPxHyperLink ID="lnkDelete" runat="server" Text="Delete" NavigateUrl="javascript:void(0);"
                                OnInit="lnkDelete_Init" OnLoad="lnkDelete_Load">
                                <DisabledStyle ForeColor="gray" />
                            </dx:ASPxHyperLink>
                        </DataItemTemplate>
                        <EditFormSettings Visible="False" />
                        <Settings AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False"
                            AllowAutoFilter="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SupplierID" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="QuantityPerUnit" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="sds" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                SelectCommand="SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit] FROM [Products]">
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
