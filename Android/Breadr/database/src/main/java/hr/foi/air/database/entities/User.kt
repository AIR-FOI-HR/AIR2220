package hr.foi.air.database.entities

import androidx.room.*
import hr.foi.air.core.entities.User


@Entity(tableName = "users", primaryKeys = ["userId"])
class User() : User() {
    @PrimaryKey(autoGenerate = true)
    @Ignore
    override var userId: Int? = null
}