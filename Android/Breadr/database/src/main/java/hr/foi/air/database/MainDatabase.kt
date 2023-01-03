package hr.foi.air.database

import android.content.Context
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import hr.foi.air.database.entities.Receipt
import hr.foi.air.database.entities.User
import hr.foi.air.database.views.CurrentUser
import hr.foi.air.database.views.ReceiptInfo


@Database(version = 7, entities = [Receipt::class, User::class], views = [ReceiptInfo::class, CurrentUser::class], exportSchema = false)
abstract class MainDatabase : RoomDatabase() {
    abstract fun getDao(): DAO

    companion object
    {
        private var instance : MainDatabase? = null

        fun getInstance(context : Context) : MainDatabase
        {
            if (instance == null)
            {
                instance = Room.databaseBuilder(
                    context.applicationContext,
                    MainDatabase::class.java, "main.db"
                )
                    .allowMainThreadQueries()
                    .fallbackToDestructiveMigration()
                    .build()
            }

            return instance as MainDatabase
        }
    }
}