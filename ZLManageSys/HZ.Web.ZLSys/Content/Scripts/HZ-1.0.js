var data_none_html = '<div style="text-align:center;color:red">无记录</div>';//无数据显示
var power_modify = false;//编辑权限
var where1 = '';//已执行的查询条件
/*日期格式化*/
function DateToStr(date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
}
/*时间格式化*/
function DateTimeToStr(date) {
    var y = date.getFullYear();
    var mo = date.getMonth() + 1;
    var d = date.getDate();
    var h = date.getHours();
    var mi = date.getMinutes();
    return y + '-' + (mo < 10 ? ('0' + mo) : mo) + '-' + (d < 10 ? ('0' + d) : d) + ' ' + (h < 10 ? ('0' + h) : h) + ':' + (mi < 10 ? ('0' + mi) : mi);
}
/*字符转日期*/
function StrToDate(s) {
    if (!s) return new Date();
    //var ss = (s.split('-'));
    //var y = parseInt(ss[0], 10);
    //var m = parseInt(ss[1], 10);
    //var d = parseInt(ss[2], 10);
    //if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
    //    return new Date(y, m - 1, d);
    //} else {
    //    return new Date();
    //}
    var t = Date.parse(s);
    if (!isNaN(t)) {
        return new Date(t);
    } else {
        return new Date();
    }
}

//日期(字符串)相加，返回字符串
function StrDateAdd(s, n) {
    var f = StrToDate(s);
    var t = f.setDate(f.getDate() + n);
    return DateToStr(new Date(t));
}
//日期相加，返回日期
function DateAdd(d, n) {
    var t = d.setDate(d.getDate() + n);
    return new Date(t);
}
//本月第一天
function MonthFirstDate(d) {
    var f = d.setDate(1);
    return new Date(f);
}
//转换json日期
function renderDate(jsondate) {
    var d = new Date(parseInt(jsondate.replace("/Date(", "").replace(")/", "").split("+")[0]));
    return DateToStr(d);
}
//转换json时间
function renderDateTime(jsondate) {
    var d = new Date(parseInt(jsondate.replace("/Date(", "").replace(")/", "").split("+")[0]));
    return DateTimeToStr(d);
}
////开始日期
//function STonSelect(date) {
//    var ymd = "";
//    var y = date.getFullYear();
//    var m = date.getMonth() + 1;
//    var d = date.getDate();
//    ymd = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
//    return document.getElementById("staday").value = ymd;
//}
////结束日期
//function ETonSelect(date) {
//    var ymd = "";
//    var y = date.getFullYear();
//    var m = date.getMonth() + 1;
//    var d = date.getDate();
//    ymd = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
//    return document.getElementById("enday").value = ymd;
//}
/*查询1*/
function doSearch1(dgid, where, value, name, url) {
    where1 = where;
     if (name != "all") {
        if (value != "") {
            if (where1 != "") {
                where1 += " and ";
            }
              where1 += name + " like  '%" + value + "%'";

            if (url) {
                $(dgid).datagrid({ url: url + '?sw=' + encodeURIComponent(where1) });
            }
            else {
                $(dgid).datagrid('load', { sw: where1 });
            }
        }
        else {
            $.messager.alert('提示', '请输入关键字！', 'warning');
        }
    }
    else {
        if (value == "") {
            if (url) {
                $(dgid).datagrid({ url: url + '?sw=' + encodeURIComponent(where1) });
            }
            else {
                $(dgid).datagrid('load', { sw: where1 });
            }
        }
        else {
            $.messager.alert('提示', '请选择条件！', 'warning');
        }
    }
}
/*查询2*/
function doSearch2(dgid, where, sb1, sb2, url) {
    where1 = where;
    if (sb1) {
        var name1 = $(sb1).searchbox('getName');
        var value1 = $(sb1).searchbox('getValue');
        value1 = String(value1).trim();
        if (value1 != '') {
            if (where1 != "") {
                where1 += " and ";
            }
            where1 += name1 + " like '%" + value1 + "%'";
        }
    }
    if (sb2) {
        var name2 = $(sb2).searchbox('getName');
        var value2 = $(sb2).searchbox('getValue');
        value2 = String(value2).trim();
        if (value2 != '') {
            if (where1 != "") {
                where1 += " and ";
            }
            where1 += name2 + " like '%" + value2 + "%'";
        }
    }
    if (url) {
        $(dgid).datagrid({ url: url + '?sw=' + encodeURIComponent(where1) });
    }
    else {
        $(dgid).datagrid('load', { sw: where1 });
    }
}

/*刷新数据列表*/
function CallBack1(dgid) {
    $(dgid).datagrid('reload');
}
/*保存记录*/
function doSave1(dlgid, fmid, url, dgid, bnid) {
    var bnname = '确定';
    if (bnid) {
        $('#' + bnid).linkbutton('disable');
        bnname = $('#' + bnid + ' span[class=l-btn-text]').html();
        $('#' + bnid + ' span[class=l-btn-text]').html('正在执行,请稍后...')
    }
    $(fmid).form('submit', {
        url: url,
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (result) {
            if (result == "保存成功!") {
                $(dlgid).dialog('close');
                //$.messager.alert("提示", result);
                CallBack1(dgid);//重载记录  
            }
            else {
                $.messager.alert("提示", result);
            }
            if (bnid) {
                $('#' + bnid + ' span[class=l-btn-text]').html(bnname)
                $('#' + bnid).linkbutton('enable');
            }
        }
    });
}
/*删除记录*/
function doDelete1(url, ids, dgid) {
    if (ids.length != 0) {
        $.messager.confirm('提示', '确认要删除所选记录吗？', function (r) {
            if (r) {
                $.post(url, { ids: ids }, function (result) {
                    if (result == "删除成功!") {
                        //$.messager.alert("提示", result);
                        CallBack1(dgid);//重载记录 
                    } else {
                        $.messager.alert("提示", result);
                    }
                });
            }
        });
    }
    else {
        $.messager.alert("提示", "请选择一条或多条记录！", "warning");
    }
}

/*审核记录*/
function doAffirm1(url, ids, dgid) {
    if (ids.length != 0) {
        $.messager.confirm('提示', '确认要审核所选记录吗？', function (r) {
            if (r) {
                $.post(url, { ids: ids }, function (result) {
                    if (result == "审核成功!") {
                        //$.messager.alert("提示", result);
                        CallBack1(dgid);//重载记录 
                    } else {
                        $.messager.alert("提示", result);
                    }
                });
            }
        });
    }
    else {
        $.messager.alert("提示", "请选择一条或多条记录！", "warning");
    }
}
/*撤销审核记录*/
function doAffirm2(url, ids, dgid) {
    if (ids.length != 0) {
        $.messager.confirm('提示', '确认要撤销审核所选记录吗？', function (r) {
            if (r) {
                $.post(url, { ids: ids }, function (result) {
                    if (result == "撤销审核成功!") {
                        //$.messager.alert("提示", result);
                        CallBack1(dgid);//重载记录 
                    } else {
                        $.messager.alert("提示", result);
                    }
                });
            }
        });
    }
    else {
        $.messager.alert("提示", "请选择一条或多条记录！", "warning");
    }
}
/*加载默认值,打开编辑窗口:新增*/
function loadData1(dlgid, fmid, data, title) {
    $(fmid).form('clear');//清空from
    var title1 = "新建";
    if (title) {
        title1 = title;
    }
    if (data) {
        $(fmid).form('load', data);
    }
    $(dlgid).dialog('open').dialog('setTitle', title1);
}
/*加载实体,打开编辑窗口:修改*/
function loadData2(dlgid, fmid, getmodel_url, id, title) {
    $(fmid).form('clear');//清空from
    var title1 = '修改[' + id + ']';
    if (title) {
        title1 = title;
    }
    if (getmodel_url && id != "") {
        if (!power_modify) {
            //$.messager.alert("提示", "你没有编辑权限！", "warning");
            return;
        }
        //$.getJSON(getmodel_url, { id: id }, function (data) {
        //    if (data) {
        //        $(fmid).form('load', data);
        //    }
        //});
        //解决getJSON缓存问题
        $.ajax({
            type: 'get',
            url: getmodel_url,
            data: { 'id': id },
            dataType: 'json',
            cache: false,
            success: function (data) {
                if (data) {
                    $(fmid).form('load', data);
                }
            }
        });
    }
    else {
        $.messager.alert("提示", "请选择一条记录！", "warning");
        return;
    }
    $(dlgid).dialog('open').dialog('setTitle', title1);
}
/*datagird数据绑定调整*/
function fitDatagirdBind(dgid, data_none, field, colspan, ck) {
    $(dgid).datagrid({
        onLoadSuccess: function (data) {
            if (data.total == 0) {
                $(this).datagrid('appendRow', data_none);
                $(this).datagrid('mergeCells', { index: 0, field: field, colspan: colspan });
                if (ck) {
                    $(this).datagrid('hideColumn', ck);
                }
                $(this).closest('div.datagrid-wrap').find('div.datagrid-pager').hide();
            }
            else {
                if (ck) {
                    $(this).datagrid('showColumn', ck);
                }
                $(this).closest('div.datagrid-wrap').find('div.datagrid-pager').show();
            }
        },
    });
}

/*物料信息查看窗口*/
function ItemView(code) {
    if (code) {
        $('#dlgitvw').dialog({
            title: '查看物料信息[' + code + ']',
            //href: '/ItemInfo/ItemView?code=' + code,
            width: 770,
            height: 480,
            shadow: true,
            modal: true
        });
        $('#dlgitvw').dialog('refresh', '/ItemInfo/ItemView?code=' + code);
    }
    else {
        $.messager.alert("提示", "请选择一条记录！", "warning");
    }
}
/*供应商查看窗口*/
function SupView(code) {
    if (code) {
        $('#dlgspvw').dialog({
            title: '查看供应商信息[' + code + ']',
            //href: '/SUPPLIER/SupView?code=' + code,
            width: 770,
            height: 420,
            shadow: true,
            modal: true
        });
        $('#dlgspvw').dialog('refresh', '/SUPPLIER/SupView?code=' + code);
    }
    else {
        $.messager.alert("提示", "请选择一条记录！", "warning");
    }
}
///*物料下拉列表格式化*/ 拖慢速度，禁用
//function itddlformatter(row) {
//    var s = '<span style="color:#999">' + row.ItemCode + '</span><br/><span>' + row.ItemName + '</span>';
//    return s;
//}
///*供应商下拉列表格式化*/ 拖慢速度，禁用
//function spddlformater(row) {
//    var s = '<span style="color:#999">' + row.SupplierCode + '</span><br/><span>' + row.SupplierName + '</span>';
//    return s;
//}
/*物料行格式输出*/
function itrowformater(value, row, index) {
    if (value && value != data_none_html) {
        return "<a href='javascript:void(0)' onclick='ItemView(\"" + value + "\")'>" + value + "</a>";
    }
    else {
        return "";
    }
}
/*供应商行格式输出*/
function sprowformater(value, row, index) {
    if (value && value != data_none_html) {
        return "<a href='javascript:void(0)' onclick='SupView(\"" + value + "\")'>" + value + "</a>";
    }
    else {
        return "";
    }
}

/*joson返回数据库的时间格式为/Date(...),转换函数*/
function ChangeDateFormat(val) {
    if (val != null) {
        var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10)); //月份为0-11，所以+1，月份小于10时补个0 
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        return date.getFullYear() + "-" + month + "-" + currentDate;
    }
    return "";
}

/*物料下拉控加载数据成功添加验证*/
function onLoadSuccessItemCode() {
    $('#ItemCode').next('.combo').find('input').blur(function () {
        var val = $('#ItemCode').combobox('getValue');
        var txt = $('#ItemCode').combobox('getText');
        if (val != '' || txt != '') {
            if (val.indexOf(txt) >= 0 || txt.indexOf(val) >= 0) {
                $('#ItemCode').combobox('clear');
                $('#ItemCodeShow').textbox('setValue', '');
            }
        }
    });
}
/*供应商下拉控加载数据成功添加验证*/
function onLoadSuccessSupplierCode() {
    $('#SupplierCode').next('.combo').find('input').blur(function () {
        var val = $('#SupplierCode').combobox('getValue');
        var txt = $('#SupplierCode').combobox('getText');
        if (val != '' || txt != '') {
            if (val.indexOf(txt) >= 0 || txt.indexOf(val) >= 0)
            {
                $('#SupplierCode').combobox('clear');
                $('#SupplierCodeShow').textbox('setValue', '');
            }
        }
    });
}

//鼠标悬停效果
function overformater(value, row, index) {
    return '<span title=' + value + '>' + value + '</span>';
}



String.prototype.PadLeft = function (totalWidth, paddingChar) {

    if (paddingChar != null) {

        return this.PadHelper(totalWidth, paddingChar, false);

    } else {

        return this.PadHelper(totalWidth, ' ', false);

    }

}

String.prototype.PadRight = function (totalWidth, paddingChar) {

    if (paddingChar != null) {

        return this.PadHelper(totalWidth, paddingChar, true);

    } else {

        return this.PadHelper(totalWidth, ' ', true);

    }



}

String.prototype.PadHelper = function (totalWidth, paddingChar, isRightPadded) {


    if (this.length < totalWidth) {

        var paddingString = new String();

        for (i = 1; i <= (totalWidth - this.length) ; i++) {

            paddingString += paddingChar;

        }



        if (isRightPadded) {

            return (this + paddingString);

        } else {

            return (paddingString + this);

        }

    } else {

        return this;

    }

}