//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaVirtual
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compra
    {
        public int Id { get; set; }
        public int compradoQuantity { get; set; }
        public double compradoProductoAmount { get; set; }
        public int ProductoId { get; set; }
    
        public virtual Producto Producto { get; set; }
    }
}
