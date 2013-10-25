<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Main.aspx.cs" Inherits="Admin_Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" background="images/tab_05.gif">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12" height="30">
                                <img src="images/tab_03.gif" width="12" height="30" />
                            </td>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="46%" valign="middle">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <div align="center">
                                                                        <img src="images/tb.gif" width="16" height="16" /></div>
                                                                </td>
                                                                <td width="95%">
                                                                    <span class="titleBold12px">系统说明</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                        </td>
                                        <td width="54%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="16">
                                <img src="images/tab_07.gif" width="16" height="30" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="8" background="images/tab_12.gif">
                                &nbsp;
                            </td>
                            <td>
                                <ul>
                                    <li>销售管理
                                    <ul>
                                        <li>销售订单添加：查询顾客或添加顾客，添加订单。添加订单后，请设置用料单明细。修改完毕后，请提交审核。</li>
                                        <li>销售订单列表：查看订单列表，显示各订单状态，可修改未提交的用料单明细。</li>
                                        <li>销售订单收款管理：顾客付款。</li>
                                        <li>订单流程管理：查看各订单流程状态。已完工的订单，请设置完工日期。统计时未完工的订单不计算在内。</li>
                                    </ul>
                                    </li>
                                    <li>订货管理
                                    <ul>
                                        <li>待订货用料单列表：根据用料单，生成相应的订货单。可修改订货明细信息。</li>
                                        <li>订货明细管理：查看订货单列表，修改订货明细。</li>
                                        <li>成本价格及付款管理：设置订货单明细成本价格，给厂家付款。</li>
                                    </ul>
                                    </li>
                                    <li>仓库管理
                                    <ul>
                                        <li>仓库列表：查看仓库信息。</li>
                                        <li>到货入库管理：根据订货单，设置订货单明细到货入库情况。</li>
                                        <li>出库单及明细管理：根据用料单，生成相应的出库单，可增加辅料等明细。</li>
                                        <li>出库管理：根据出库单，设置出库单明细的出库情况。</li>
                                        <li>查看库存：查看各材料的库存情况。</li>
                                    </ul>
                                    </li>
                                    <li>财务管理
                                    <ul>
                                        <li>账户管理：添加、查看、修改账户信息。</li>
                                        <li>查看账户余额。</li>
                                        <li>收支类别管理：设置收支类别。</li>
                                        <li>收入明细添加。</li>
                                        <li>支出明细添加。</li>
                                        <li>转账明细添加。</li>
                                        <li>收支明细列表：查看指定日期内的收支明细详情。</li>
                                    </ul>
                                    </li>
                                    <li>厂家管理
                                    <ul>
                                        <li>厂家添加：添加厂家信息。</li>
                                        <li>厂家列表：查看、修改厂家信息。</li>
                                    </ul>
                                    </li>
                                    <li>材料管理
                                    <ul>
                                        <li>材料类别管理：设置材料类别。</li>
                                        <li>材料添加：添加材料信息。</li>
                                        <li>材料列表：查看、修改材料信息。</li>
                                    </ul>
                                    </li>
                                    <li>查询统计
                                    <ul>
                                        <li>材料成本及销售金额查询：查询统计指定日期内的各厂家材料成本及销售金额。以完工的订单为准，未完工的订单不统计。可导出Excel。</li>
                                    </ul>
                                    </li>
                                    <li>系统设置
                                    <ul>
                                        <li>修改密码：修改本用户登录密码。</li>
                                    </ul>
                                    </li>
                                    <li>其他说明
                                    <ul>
                                        <li>涉及金额的输入输出，均保留两位小数。</li>
                                    </ul>
                                    </li>
                                </ul>
                            </td>
                            <td width="8" background="images/tab_15.gif">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="35" background="images/tab_19.gif">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12" height="35">
                                <img src="images/tab_18.gif" width="12" height="35" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="16">
                                <img src="images/tab_20.gif" width="16" height="35" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
