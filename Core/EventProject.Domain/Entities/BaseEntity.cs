namespace EventProject.Domain.Entities;

public abstract class BaseEntity
{

    public Guid Id { get; set; } 
                                               
    public DateTime? CreatedDate { get; set; } 

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; } = null;

    public bool? IsDeleted { get; set;}=false;

}

//var sql = @"INSERT INTO Images (FileName, Location, CreatedAt) 
//                    VALUES (@FileName, @Location, @CreatedAt);
//                    SELECT CAST(SCOPE_IDENTITY() as int);"
//;

//var _connection = OpenConnection();
//        return await _connection.ExecuteScalarAsync<int>(sql, image);