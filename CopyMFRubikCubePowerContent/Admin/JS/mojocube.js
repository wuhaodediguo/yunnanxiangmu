
//һ���ӡ
function McPrint() {
    window.print();
}

//�����ض�Ԫ�ش�ӡ����.btn�����Ԫ���ö��Ÿ�������.btn1,.btn2
function McPrintHide(element) {
    $(element).hide();
    window.print();
    $(element).show();
}

//�ϴ�ͼƬ��鲢��ʾԤ��ͼ
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

   


////�ϴ�ͼƬ��鲢��ʾԤ��ͼ
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