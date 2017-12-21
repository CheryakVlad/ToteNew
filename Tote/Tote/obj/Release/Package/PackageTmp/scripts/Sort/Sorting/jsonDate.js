function jsonDate(date) {
    var str, year, month, day, hour, minute, d, finalDate;

    str = date.replace(/\D/g, "");
    d = new Date(parseInt(str));

    year = d.getFullYear();
    month = pad(d.getMonth() + 1);
    day = pad(d.getDate());
    hour = pad(d.getHours());
    minutes = pad(d.getMinutes());

    finalDate = year + "-" + month + "-" + day + " " + hour + ":" + minutes + ":00";
    return finalDate;
}
function pad(num) {
    num = "0" + num;
    return num.slice(-2);
}