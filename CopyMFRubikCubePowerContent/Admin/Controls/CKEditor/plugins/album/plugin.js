(function () {
    //Section 1 : �����Զ��尴ťʱִ�еĴ��� 
    var a = {
        exec: function (editor) {
            $.fancybox.open({
                href: '../Commons/Album.aspx',
                type: 'iframe',
                padding: 5
            });
        }
    },
    //Section 2 : �����Զ��尴ť���󶨷��� 
    b = 'album';
    CKEDITOR.plugins.add(b, {
        init: function (editor) {
            editor.addCommand(b, a);
            editor.ui.addButton('album', {
                label: 'Albums',
                icon: this.path + 'image_add.png',
                command: b
            });
        }
    });
})(); 