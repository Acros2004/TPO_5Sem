import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection {
    public static Connection getConnection() {
        String url = "jdbc:oracle:thin:@172.22.80.20:1521:orcl";
        String username = "system";
        String password = "Qwerty12345";

        Connection connection = null;

        try {
            Class.forName("oracle.jdbc.driver.OracleDriver");
            connection = DriverManager.getConnection(url, username, password);
            if (connection != null) {
                System.out.println("Успешное подключение к базе данных.");
            }
            return connection;
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
            return null;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }
}
