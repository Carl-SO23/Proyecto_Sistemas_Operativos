#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <mysql/mysql.h>

void finish_with_error(MYSQL* con)
{
    fprintf(stderr, "%s\n", mysql_error(con));
    mysql_close(con);
    exit(1);
}

int main()
{
    MYSQL* con = mysql_init(NULL);

    if (con == NULL)
    {
        fprintf(stderr, "mysql_init() failed\n");
        exit(EXIT_FAILURE);
    }

    // Conectar a la base de datos
    if (mysql_real_connect(con, "localhost", "tu_usuario", "tu_contrasena", "juego", 0, NULL, 0) == NULL)
    {
        finish_with_error(con);
    }

    // Consulta SQL
    if (mysql_query(con, "SELECT id, nombre, contrasena, partidas_ganadas, partidas_perdidas FROM jugadores"))
    {
        finish_with_error(con);
    }

    MYSQL_RES* result = mysql_store_result(con);
    if (result == NULL)
    {
        finish_with_error(con);
    }

    int num_fields = mysql_num_fields(result);
    MYSQL_ROW row;

    // Imprimir los resultados
    while ((row = mysql_fetch_row(result)))
    {
        for (int i = 0; i < num_fields; i++)
        {
            printf("%s ", row[i] ? row[i] : "NULL");
        }
        printf("\n");
    }

    // Liberar resultados
    mysql_free_result(result);
    mysql_close(con);

    return 0;
}

