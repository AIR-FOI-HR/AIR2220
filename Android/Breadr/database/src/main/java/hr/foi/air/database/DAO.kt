package hr.foi.air.database

import androidx.room.*
import hr.foi.air.database.entities.Receipt
import hr.foi.air.database.entities.User

@Dao
interface DAO {
    @Insert(onConflict = OnConflictStrategy.REPLACE)
    fun insertReceipt(vararg receipt: Receipt)
    @Update fun updateReceipt(vararg receipt: Receipt)
    @Delete fun deleteReceipt(vararg receipt: Receipt)

    @Insert fun insertUser(vararg user: User)
    @Update fun updateUser(vararg user: User)
    @Delete fun deleteUser(vararg user: User)

    @Query("SELECT * FROM receipts")
    fun getAllReceipts(): List<Receipt>

    @Query("SELECT * FROM users WHERE email LIKE :email")
    fun getUserByEmail(email: String): User

    @Query("SELECT * FROM users WHERE userId LIKE :id")
    fun getUserById(id: Int): User

    @Query("SELECT * FROM users WHERE loggedIn == 1")
    fun getActiveUser(): User

    @Query("SELECT * FROM users")
    fun getAllUsers(): User

}
