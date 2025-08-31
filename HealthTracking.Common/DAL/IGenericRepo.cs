using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.Common.DAL
{
    public interface IGenericRepo<T> where T : class
    {
        #region -- Methods --

        //Tạo đối tượng "m" truyền vào
        void Create(T m);

        //Tạo danh sách đối tượng "l" truyền vào
        void Create(List<T> l);

        //Đọc dữ liệu theo điều kiện
        IQueryable<T> Read(Expression<Func<T, bool>> p);

        //Đọc đối tượng có id truyền vào
        T Read(int id);

        //Đọc dữ liệu theo keyword truyền vào
        T Read(string code);

        //Cập nhật đối tượng
        void Update(T m);

        //Cập nhật 1 danh sách các đối tượng
        void Update(List<T> l);

        #endregion

        #region -- Properties --

        //Trả về toàn bộ dữ liệu
        IQueryable<T> All { get; }

        #endregion
    }
}