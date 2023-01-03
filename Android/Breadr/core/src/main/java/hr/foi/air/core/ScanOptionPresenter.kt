package hr.foi.air.core

import android.content.Context
import android.graphics.drawable.Drawable
import androidx.fragment.app.Fragment

interface ScanOptionPresenter  {
    fun getIcon(context: Context) : Drawable?
    fun getName(context: Context) : String
    fun getFragment() : Fragment
}