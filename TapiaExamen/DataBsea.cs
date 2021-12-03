using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TapiaExamen
{
    public interface DataBsea
    {
        SQLiteAsyncConnection GetConnection();
    }
}
