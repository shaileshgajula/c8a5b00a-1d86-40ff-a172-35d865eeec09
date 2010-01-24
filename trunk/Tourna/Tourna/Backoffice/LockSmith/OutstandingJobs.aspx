<%@ Page Title="outstanding jobs" Language="C#" MasterPageFile="~/Backoffice/BackOffice.Master" AutoEventWireup="true" CodeBehind="OutstandingJobs.aspx.cs" Inherits="StrongerOrg.Backoffice.LockSmith.OutstandingJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript"  src="../../Scripts/GMAPJSHelper_Release.js">
    var geocoder = new GClientGeocoder();
    var x = new GMap2("dd");
    
        </script>
<input type="text" id="txtAddress"/>
    <input type="button" id="btnGo" value="Find Address" onclick="showAddress(document.getElementById('txtAddress').value)"/>
    <div id="map_canvas" style="width: 500px; height: 300px"></div>
outstanding jobs
</asp:Content>
