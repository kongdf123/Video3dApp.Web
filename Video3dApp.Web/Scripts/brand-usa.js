/**
 * Created by Administrator on 2016/11/29.
 */


//必须在服务器上才能看到效果！
window.onload=function(){
    winWidth();
    getTitleHeight();
    loadingAllImg();
}

//让全景图刚好撑满屏幕
var canvasHeight;
function getTitleHeight(){
    var title=document.getElementById('title');
    var titleHeight=parseFloat(getComputedStyle(title).height);
    var maxHeight=window.innerHeight;
    canvasHeight=parseFloat(maxHeight-titleHeight)+'px';
}
//全景图参数配置函数
function loadingAllImg(){
    var div = document.getElementById('container');
    var PSV = new PhotoSphereViewer({
        // 全景图的完整路径
        panorama: 'images/brand-usa/F1.png',

        //起初位置
        default_position: {long: -Math.PI/2, lat: 0},
        // 放全景图的元素
        container: div,
        autoload: true,
        // 可选，默认值为2000，全景图在time_anim毫秒后会自动进行动画。（设置为false禁用它）
        time_anim: false,

        // 可选值，默认为false。显示导航条。
        navbar: true,

        // 可选，默认值null，全景图容器的最终尺寸。例如：{width: 500, height: 300}。
        size: {
            width: '100%',
            height: canvasHeight
        }
    });
    var PSV = new PhotoSphereViewer({
        // 全景图的完整路径
        panorama: 'images/F1.png',

        //起初位置
        default_position: {long: -Math.PI/2, lat: 0},
        // 放全景图的元素
        container: div,
        autoload: true,
        // 可选，默认值为2000，全景图在time_anim毫秒后会自动进行动画。（设置为false禁用它）
        time_anim: false,

        // 可选值，默认为false。显示导航条。
        navbar: true,

        // 可选，默认值null，全景图容器的最终尺寸。例如：{width: 500, height: 300}。
        size: {
            width: '100%',
            height: canvasHeight
        }
    });
}
//判断浏览器窗口的宽度
function winWidth() {
  var phoneWidth = window.innerWidth;//回去iPad的宽度768
  if (phoneWidth <= 768) {
    $(".width_max").hide();
    $(".width_min").show();
  } else if(phoneWidth > 768) {
    $(".width_max").show();
    $(".width_min").hide();
  }
}