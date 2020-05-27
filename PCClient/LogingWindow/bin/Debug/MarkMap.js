var map = new BMap.Map("allmap");
var s = 108.953528;//用来接收经度的参数
var e = 34.267551;//用来接收纬度的参数
var point = new BMap.Point(s, e);//新建一个位置对象，用于设置地图中心和覆盖物位置
var marker = new BMap.Marker(point);  // 创建标注
var mapPointsArray = new Array();  //用于存储解析范围坐标组坐标数据的数组
var manPoint = new Array();//用于存储多边形的坐标的数组
//定义多边形的代码
var polygon = new BMap.Polygon([        //以某坐标点为中心给定一个三角形区域
new BMap.Point(s, e + 0.001),
new BMap.Point(s + 0.001, e - 0.001),
new BMap.Point(s - 0.001, e - 0.001)
], { strokeColor: "blue", strokeWeight: 2, strokeOpacity: 0.5 });  //创建多边形
//为保证页面在加载时可以直接显示地图，以下两句必不可少
map.centerAndZoom(point, 5);
map.enableScrollWheelZoom(true);

//为动态页面加载所提供的方法
function mainMap() {   //显示一张以西安市钟楼为中心的地图，由C#调用
    var point = new BMap.Point(108.953528, 34.267551);
    map.centerAndZoom(point, 5);
    map.clearOverlays();   //清除地图上的覆盖物
    map.enableScrollWheelZoom(true);
}
function newManMap() {   //刷新地图，且不对地图做任何更改
    var point = new BMap.Point(108.953528, 34.267551);
    map.centerAndZoom(point, 6);
    map.enableScrollWheelZoom(true);
}
function markMap(start, ending, area, name) {  //供C#调用的方法,显示指定个体的位置
    s = start;
    e = ending;
    map.clearOverlays();   //清除地图上的覆盖物
    var point = new BMap.Point(s, e);
    map.centerAndZoom(point, 18);
    marker.setPosition(point);
    map.addOverlay(marker);               // 将标注添加到地图中
    marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画
    isInArea(s, e, area, name);   //调用判断点与区位置函数
}

function mapAeraPoints(recivePoits) {  //用于解析string数据，并给出活动范围图形的函数,由JS调用，recivePoits参数为一个string对象
    var ss = new String(recivePoits);
    var pointNum = 0;  //用于计算C#传向js的坐标组数的变量
    mapPointsArray.length = 0;  //将用于解析范围坐标组的数组清零
    //计算数据组数代码块
    while (ss.indexOf("ra") >= 0)   //获取字符串中坐标位置的组数，js和C#中不同的是indexOf方法的首字母，js中小写，C#大写
    {
        ss = ss.substring(ss.indexOf("ra") + "ra".length);
        pointNum++;
    }
    ss = recivePoits;
    //解析数据代码块
    for (i = 0; i < pointNum; i++) {   //解析字符串并传输
        var p = -1;
        var q = -1;
        var str1 = new String("");
        var str2 = new String("");
        p = ss.indexOf(",");//用于确定所需要所搜字符串的位置
        q = ss.indexOf("ra", p);
        str1 = ss.substring(0, p);    //该方法与C#有区别，js中的方法有重载，C#中的该方法有几种重载形式，两者参数意义不同
        str2 = ss.substring(p + 1, q);
        ss = ss.substring(ss.indexOf("ra") + "ra".length);//字符串自减运算
        mapPointsArray.push(new BMap.Point(str1, str2));   //向区域位置数组中添加数据
    }
    polygon.setPath(mapPointsArray);   //设置多边形的数据
}

function isInArea(s, e, area, name) {    //用于判断点与位置关系的函数
    var point1 = new BMap.Point(s, e);
    mapAeraPoints(area); //调用数据解析函数
    polygon.disableEditing();//设置多边形不可编辑
    var result = BMapLib.GeoUtils.isPointInPolygon(point, polygon);//用于判定点与区域位置的标志，返回结果为boolean值，若在内则返回true
    if (result == true)
    {
        //重置安全区域图形的样式，并显示
        var polygonShow = polygon;
        polygonShow.setStrokeOpacity(0);
        polygonShow.setFillOpacity(0.25);
        polygonShow.setFillColor("green");
        map.addOverlay(polygonShow);   //在地图中显示多边形
    }
    else
    {
        map.clearOverlays();   //清除地图上的覆盖物
        marker.setPosition(point1);
        map.centerAndZoom(point1, 12);
        map.addOverlay(polygon);   //在地图中显示多边形
        var bMarker = new BMap.Marker(mapPointsArray[0], {   //为多边形设置一个标注图，便于查看多边形位置
            // 指定Marker的icon属性为Symbol
            icon: new BMap.Symbol(BMap_Symbol_SHAPE_POINT, {
                scale: 1,//图标缩放大小
                fillColor: "green",//填充颜色
                fillOpacity: 0.6//填充透明度
            })
        });
        map.addOverlay(bMarker);
        map.addOverlay(marker);
        alert("工作人员请注意\n用户“" + name + "”不在安全活动范围内");
        marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画
    }
}

function savePolygon() {      //将地图页面中的多边形坐标转化成string后传给C#用于保存到数据库，由C#调用
    polygon.disableEditing();//设置多边形不可编辑
    var arrypoint = polygon.getPath();//获取多边形的坐标
    for (i = 0; i < arrypoint.length; i++) {//将多边形的坐标点赋值给特定的数组
        manPoint[i] = arrypoint[i].lng + "," + arrypoint[i].lat;
    }
    var mapAer = new String("");//将多边形数据转换成string型用于传输
    for (i = 0; i < arrypoint.length; i++) {
        mapAer += manPoint[i] + "ra";
    }
    return mapAer;   //返回区域坐标点
    //window.external.savePolygo(mapAer);//向C#传输限制区域的坐标信息和  数据个数，提供C#检测使用
}
function showPolygon() {    //设置初始状态的框图，以当前地图的中心点为中心，做一个初始的三角形
    var mapCenterPoint = map.getCenter();
    var manSc = mapCenterPoint.lng;      //获取标志物现在的坐标点，并转化为float型
    var manEc = mapCenterPoint.lat;
    polygon.setPath([    //设置多边形的形状
        new BMap.Point(manSc, manEc + 0.001),
        new BMap.Point(manSc + 0.001, manEc - 0.001),
        new BMap.Point(manSc - 0.001, manEc - 0.001)
    ]);
    map.addOverlay(polygon);   //增加多边形
    polygon.enableEditing();//设置多边形可编辑
    polygon.show();
}
function setPolygon_1(reciveArea) {     //用于在设置图形时设置一个新的历史图形区域，用户之前做好的区域，由C#调用
    mapAeraPoints(reciveArea);  //调用数据处理函数
    map.centerAndZoom(mapPointsArray[0], 16);//
    map.addOverlay(polygon);   //在地图中显示多边形
    polygon.enableEditing();//设置多边形可编辑
}


//marker.addEventListener("click", attribute);//设置鼠标离开/放置覆盖物时的动作
//marker.addEventListener("mouseover", attributel);
//function attribute() {
//    marker.setAnimation(null); //停止跳动
//}
//function attributel() {
//    marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画
//}
