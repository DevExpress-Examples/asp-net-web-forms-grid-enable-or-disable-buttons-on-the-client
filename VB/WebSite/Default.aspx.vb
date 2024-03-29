﻿Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	' Init 

	Protected Sub lnkEdit_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim lnk As ASPxHyperLink = TryCast(sender, ASPxHyperLink)
		Dim container As GridViewDataItemTemplateContainer = TryCast(lnk.NamingContainer, GridViewDataItemTemplateContainer)

		lnk.ClientInstanceName = String.Format("lnkEdit{0}", container.VisibleIndex)
		lnk.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.StartEditRow ({1}); }}", (If(String.IsNullOrEmpty(container.Grid.ClientInstanceName), container.Grid.ClientID, container.Grid.ClientInstanceName)), container.VisibleIndex)
	End Sub

	Protected Sub lnkNew_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim lnk As ASPxHyperLink = TryCast(sender, ASPxHyperLink)
		Dim container As GridViewDataItemTemplateContainer = TryCast(lnk.NamingContainer, GridViewDataItemTemplateContainer)

		lnk.ClientInstanceName = String.Format("lnkNew{0}", container.VisibleIndex)
		lnk.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.AddNewRow (); }}", (If(String.IsNullOrEmpty(container.Grid.ClientInstanceName), container.Grid.ClientID, container.Grid.ClientInstanceName)))
	End Sub

	Protected Sub lnkDelete_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim lnk As ASPxHyperLink = TryCast(sender, ASPxHyperLink)
		Dim container As GridViewDataItemTemplateContainer = TryCast(lnk.NamingContainer, GridViewDataItemTemplateContainer)

		lnk.ClientInstanceName = String.Format("lnkDelete{0}", container.VisibleIndex)
		lnk.ClientSideEvents.Click = String.Format("function (s, e) {{ {0}.DeleteRow ({1}); }}", (If(String.IsNullOrEmpty(container.Grid.ClientInstanceName), container.Grid.ClientID, container.Grid.ClientInstanceName)), container.VisibleIndex)
	End Sub

	' Load 

	Protected Sub lnkEdit_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim lnk As ASPxHyperLink = TryCast(sender, ASPxHyperLink)

		lnk.ClientEnabled = Not chkEdit.Checked
	End Sub

	Protected Sub lnkNew_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim lnk As ASPxHyperLink = TryCast(sender, ASPxHyperLink)

		lnk.ClientEnabled = Not chkNew.Checked
	End Sub

	Protected Sub lnkDelete_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim lnk As ASPxHyperLink = TryCast(sender, ASPxHyperLink)

		lnk.ClientEnabled = Not chkDelete.Checked
	End Sub
End Class
