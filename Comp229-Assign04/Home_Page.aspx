﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home_Page.aspx.cs" Inherits="Comp229_Assign04._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <table>
        <asp:Repeater ID="modelsRep" runat="server" >
<ItemTemplate>
    <tr>
        <td>
            <asp:HyperLink runat="server" NavigateUrl='<%#String.Format("~/SingleModel.aspx?name={0}&faction={1}",Eval("name"),Eval("faction")) %>'>
<asp:Label runat="server"><%#Eval("name") %></asp:Label>
                
            </asp:HyperLink>
        </td>
        <td>
<asp:Label runat="server"><%#Eval("faction") %></asp:Label>
        </td>
    </tr>
</ItemTemplate>


        </asp:Repeater>

    </table>
     </div>
    </asp:Content>
 