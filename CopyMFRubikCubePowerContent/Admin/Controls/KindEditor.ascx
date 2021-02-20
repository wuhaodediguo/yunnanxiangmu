<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KindEditor.ascx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.Controls.KindEditor" %>

<link rel="stylesheet" href="../Controls/KindEditor/themes/default/default.css" />
<link rel="stylesheet" href="../Controls/KindEditor/plugins/code/prettify.css" />
<script charset="utf-8" src="../Controls/KindEditor/kindeditor.js"></script>
<script charset="utf-8" src="../Controls/KindEditor/lang/zh_CN.js"></script>
<script charset="utf-8" src="../Controls/KindEditor/plugins/code/prettify.js"></script>

<script>
    KindEditor.ready(function (K) {
        window.editor = K.create('#ctl00_cphMain_txtContent_content1',
            {
                uploadJson: '../Controls/KindEditor/asp.net/upload_json.ashx',
                fileManagerJson: '../Controls/KindEditor/asp.net/file_manager_json.ashx',
                filterMode: false
            });
    });
</script>

<textarea id="content1" name="content" runat="server"></textarea>