<%@ Page Title="" Language="C#" MasterPageFile="~/OrganisationSite/OrgSite.Master"
    AutoEventWireup="true" CodeBehind="JqueryTests.aspx.cs" Inherits="StrongerOrg.JqueryTests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $('#opener').click(function() {
            //$('#dialog').dialog('open');
            alert("dd");
       }


        //        $(function () {
        //            // a workaround for a flaw in the demo system (http://dev.jqueryui.com/ticket/4375), ignore!
        //            $("#dialog").dialog("destroy");

        //            $("#dialog-confirm").dialog({
        //                resizable: false,
        //                height: 140,
        //                modal: true,
        //                buttons: {
        //                    'Delete all items': function () {
        //                        $(this).dialog('close');
        //                    },
        //                    Cancel: function () {
        //                        $(this).dialog('close');
        //                    }
        //                }
        //            });
        //        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dialog" title="Basic dialog">
        <p>
            This is the default dialog which is useful for displaying information. The dialog
            window can be moved, resized and closed with the 'x' icon.</p>
    </div>
    <button id="opener" class="opener" type="button">
        Open the dialog</button>
</asp:Content>
