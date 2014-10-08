$(function() {
    $(".tfooter td").css("border", "0");
    $(".table tr").each(function(i) {
        if (i % 2 == 0) {
            $(".tablebody table tr").eq(i).addClass("tcell_two");
        } else {
            $(".tablebody table tr").eq(i).addClass("tcell_one");

        }
    });
    $(".add").click(function() {
        lhgdialog.opendlg('内容页为外部连接的窗口', $("#" + this.id).attr("rel"), 640, 540, false, true);
    });

});