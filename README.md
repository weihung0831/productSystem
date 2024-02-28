# productSystem

## 使用 DB First 方式生成 Model 和和  DbContext

```bash
Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models