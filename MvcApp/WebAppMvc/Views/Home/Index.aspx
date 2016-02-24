<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE HTML>
<html lang="zh-cn">
<head>
    <meta charset="utf-8" />
    <title>测试</title>
</head>
<body>
    <div>
        <strong><%:ViewData["test"] %>
            <br />
            <%:ViewBag.Test %></strong>
        <%--<%:Html.ListBox("Count") %>--%>
        <label for="Gender">女</label><%: Html.RadioButton("Gender","2",false) %>
        
    </div>
</body>
</html>
