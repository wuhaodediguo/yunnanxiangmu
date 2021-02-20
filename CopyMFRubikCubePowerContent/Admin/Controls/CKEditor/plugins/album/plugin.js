(function () {
    //Section 1 : 按下自定义按钮时执行的代码 
    var a = {
        exec: function (editor) {
            $.fancybox.open({
                href: '../Commons/Album.aspx',
                type: 'iframe',
                padding: 5
            });
        }
    },
    //Section 2 : 创建自定义按钮、绑定方法 
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