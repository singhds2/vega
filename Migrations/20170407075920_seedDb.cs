using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;


namespace Vega.Migrations
{
    public partial class seedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
           migrationBuilder.Sql( "Insert into Makes(name) values ('Make1') ");
           migrationBuilder.Sql( "Insert into Makes(name) values ('Make2') ");
           migrationBuilder.Sql( "Insert into Makes(name) values ('Make3') ");
           migrationBuilder.Sql( "Insert into Models(name,makeid) values ('Make1-Model-A',(select id from Makes where name='Make1')) ");
            migrationBuilder.Sql( "Insert into Models(name,makeid) values ('Make1-Model-B',(select id from Makes where name='Make1')) ");
            migrationBuilder.Sql( "Insert into Models(name,makeid) values ('Make2-Model-A',(select id from Makes where name='Make2')) ");
            migrationBuilder.Sql( "Insert into Models(name,makeid) values ('Make2-Model-B',(select id from Makes where name='Make2')) ");
           migrationBuilder.Sql( "Insert into Models(name,makeid) values ('Make3-Model-A',(select id from Makes where name='Make3')) ");
           migrationBuilder.Sql( "Insert into Models(name,makeid) values ('Make3-Model-B',(select id from Makes where name='Make3')) ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
       migrationBuilder.Sql("Delete from Makes");
       

        }
    }
}
