<%@ Control Language="C#" AutoEventWireup="true" Codebehind="pm.ascx.cs" Inherits="YAF.Pages.pm" %>
<%@ Register TagPrefix="YAF" Namespace="YAF.Controls" Assembly="YAF.Controls" %>
<%@ Register TagPrefix="YAF" TagName="PMList" Src="../controls/PMList.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="True" />
<YAF:PageLinks runat="server" ID="PageLinks" />
<div align="right" style="float:right;"><asp:HyperLink runat="server" ID="NewMessageLink" CssClass="largetext"></asp:HyperLink></div>
<asp:UpdatePanel runat="server" ID="PMUpdatePanel">
    <ContentTemplate>
    <ajaxToolkit:TabContainer runat="server" ID="PMTabs">
        <ajaxToolkit:TabPanel runat="server" ID="InboxTab">
            <ContentTemplate>
                <YAF:PMList runat="server" View="Inbox" ID="InboxPMList" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="OutboxTab">
            <ContentTemplate>
                <YAF:PMList runat="server" View="Outbox" ID="OutboxPMList" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="ArchiveTab">
            <ContentTemplate>
                <YAF:PMList runat="server" View="Archive" ID="ArchivePMList" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    </ContentTemplate>
</asp:UpdatePanel>

<br />