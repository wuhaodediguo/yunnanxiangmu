
//一般打印
function McPrint() {
    window.print();
}

//隐藏特定元素打印，如.btn，多个元素用逗号隔开，如.btn1,.btn2
function McPrintHide(element) {
    $(element).hide();
    window.print();
    $(element).show();
}

//上传图片检查并显示预览图
function ChkUploadImage(ct_file, ct_image) {
    var fileext = ct_file.value.substring(ct_file.value.lastIndexOf("."), ct_file.value.length);
    fileext = fileext.toLowerCase();
    if ((fileext != '.jpg') && (fileext != '.gif') && (fileext != '.jpeg') && (fileext != '.png')) {
        alert("Please upload image.");
        ct_file.focus();
        ct_file.outerHTML = ct_file.outerHTML;
    }
    else {
        ct_image.style.display = "block";
        ct_image.src = window.URL.createObjectURL(ct_file.files[0])
    }
}

   


////上传图片检查并显示预览图
//function ChkUploadExcel(ct_file, ct_image) {
//    var fileext = ct_file.value.substring(ct_file.value.lastIndexOf("."), ct_file.value.length);
//    fileext = fileext.toLowerCase();
//    if ((fileext != '.xls') && (fileext != '.xlsx')) {
//        alert("Please upload Excel.");
//        ct_file.focus();
//        ct_file.outerHTML = ct_file.outerHTML;
//    }
//    else {
//        ct_image.style.display = "block";
//        ct_image.src = window.webkitURL.createObjectURL(ct_file.files[0])
//    }
//}