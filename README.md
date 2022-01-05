# design-pattern
### Cần add 2 cái này trong thư mục `dll cần add` bằng cách mở project lên và nhấn chuột phải vào `References` chọn Add References và nhấn Browser chọn 2 file

Trong đó:

- Microsoft.Office.Interop.Excel.dll để xuất excel
- DarrenLee.Translator.dll để dịch văn bản 


### Để xuất được hóa đơn, cần phải chỉnh lại url tại dòng 33 file FormReportBill.cs với nội dung như sau: 

`reportViewer1.LocalReport.ReportPath = @"D:\Java\Design Pattern\CuoiKi\new\design-pattern\CuaHangPhanMem\Reports\ReportBill.rdlc";`

Trong đó: `@"D:\Java\Design Pattern\CuoiKi\new\design-pattern\CuaHangPhanMem\Reports\ReportBill.rdlc"` là đường dẫn tuyệt đối tới Reports\ReportBill.rdlc
