<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="Admin_Left" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>后台管理左侧菜单</title>
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/chili-1.7.pack.js"></script>
<script type="text/javascript" src="js/jquery.easing.js"></script>
<script type="text/javascript" src="js/jquery.dimensions.js"></script>
<script type="text/javascript" src="js/jquery.accordion.js"></script>
<script language="javascript" type="text/javascript">
    jQuery().ready(function () {
        jQuery('#navigation').accordion({
            header: '.head',
            navigation1: true,
            event: 'click',
            fillSpace: false,
            animated: 'bounceslide'
        });
    });
</script>
<style type="text/css">

body {
	margin:0px;
	padding:0px;
	font-size: 12px;
}
#navigation {
	margin:0px;
	padding:0px;
	width:147px;
}
#navigation a.head {
	cursor:pointer;
	background:url(images/main_34.gif) no-repeat scroll;
	display:block;
	font-weight:bold;
	margin:0px;
	padding:5px 0 5px;
	text-align:center;
	font-size:12px;
	text-decoration:none;
}
#navigation ul {
	border-width:0px;
	margin:0px;
	padding:0px;
	text-indent:0px;
}
#navigation li {
	list-style:none; display:inline;
}
#navigation li li a {
	display:block;
	font-size:12px;
	text-decoration: none;
	text-align:center;
	padding:3px;
}
#navigation li li a:hover {
	background:url(images/tab_bg.gif) repeat-x;
		border:solid 1px #adb9c2;
}

</style>
</head>
<body>
    <form id="form1" runat="server">
   <div  >
  <ul id="navigation">
  <li> <a class="head">权限管理</a>
    <ul>
      <li><a href="Admin/admin_Login.aspx" target="I2"> 权限登陆</a></li>
    </ul>
  </li>
  <li> <a class="head">销售管理</a>
      <ul>
        <li><a href="Sales/SalesOrderAdd.aspx" target="I2">销售订单添加</a></li>
        <li><a href="Sales/SalesOrderList.aspx" target="I2">销售订单列表</a></li>
        <li><a href="Sales/SalesOrderListForPaymentManage.aspx" target="I2">销售订单收款退款管理</a></li>
        <li><a href="Sales/SalesOrderListForProcessManage.aspx" target="I2">订单流程管理</a></li>
      </ul>
    </li>
    <li> <a class="head">订货管理</a>
      <ul>
        <li><a href="Sales/NeedMaterialListForPurchaseOrderHeader.aspx" target="I2">待订货用料单列表</a></li>
        <li><a href="Sales/PurchaseOrderHeaderList.aspx" target="I2">订货明细管理</a></li>
        <li><a href="Sales/PurchaseOrderHeaderListForCostUnitPriceAndPaymentManage.aspx" target="I2">成本价格及付款管理</a></li>
      </ul>
    </li>
    <li> <a class="head">仓库管理</a>
      <ul>
        <li><a href="Sales/LocationManage.aspx" target="I2">仓库列表</a></li>
        <li><a href="Sales/PurchaseOrderHeaderListForArrivalManage.aspx" target="I2">到货入库管理</a></li>
        <li><a href="Sales/NeedMaterialListForStockOutNoteHeader.aspx" target="I2">出库单及明细管理</a></li>
        <li><a href="Sales/StockOutNoteHeaderList.aspx" target="I2">出库管理</a></li>
        <li><a href="Sales/MaterialInventoryShow.aspx" target="I2">查看库存</a></li>
      </ul>
    </li>
    <li> <a class="head">财务管理</a>
      <ul>
        <li><a href="Sales/AccountManage.aspx" target="I2">账户管理</a></li>
        <li><a href="Sales/AccountCurrentBalanceShow.aspx" target="I2">查看账户余额</a></li>
        <li><a href="Sales/SettlementTypeManage.aspx" target="I2">收支类别管理</a></li>
        <li><a href="Sales/SettlementInputAdd.aspx" target="I2">收入明细添加</a></li>
        <li><a href="Sales/SettlementOutputAdd.aspx" target="I2">支出明细添加</a></li>
        <li><a href="Sales/SettlementTransferAdd.aspx" target="I2">转账明细添加</a></li>
        <li><a href="Sales/SettlementDetailList.aspx" target="I2">收支明细列表</a></li>
      </ul>
    </li>
     <li> <a class="head">厂家管理</a>
      <ul>
        <li><a href="Sales/ManufacturerAdd.aspx" target="I2">厂家添加</a></li>
        <li><a href="Sales/ManufacturerList.aspx" target="I2">厂家列表</a></li>
      </ul>
    </li>
    <li> <a class="head">材料管理</a>
      <ul>
        <li><a href="Sales/MaterialCategoryManage.aspx" target="I2">材料类别管理</a></li>
        <li><a href="Sales/MaterialAdd.aspx" target="I2">材料添加</a></li>
        <li><a href="Sales/MaterialList.aspx" target="I2">材料列表</a></li>
      </ul>
    </li>
    <li> <a class="head">查询统计</a>
      <ul>
        <li><a href="Statistics/Statistics1.aspx" target="I2">材料成本及销售金额查询</a></li>
      </ul>
    </li>
    <li> <a class="head">系统设置</a>
      <ul>
        <li><a href="Sys/Admin_PwdEdit.aspx"  target="I2">修改密码</a></li>
      </ul>
    </li>
    <li> <a class="head">版本信息</a>
      <ul>
        <li><a href="#">企业订单管理系统</a></li>
        <li><a href="#">Ver0.1</a></li>
      </ul>
    </li>
  </ul>
   </div>
    </form>
</body>
</html>
