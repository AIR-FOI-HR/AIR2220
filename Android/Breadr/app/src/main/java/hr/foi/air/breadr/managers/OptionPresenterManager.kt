package hr.foi.air.breadr.managers

import android.content.Intent
import android.graphics.Color
import android.graphics.PorterDuff
import android.widget.Button
import android.widget.LinearLayout
import androidx.appcompat.app.AppCompatActivity
import hr.foi.air.breadr.MainActivity
import hr.foi.air.breadr.PurchaseActivity
import hr.foi.air.breadr.R
import hr.foi.air.breadr.databinding.ActivityMainBinding
import hr.foi.air.breadr.fragments.BuyFragment
import hr.foi.air.breadr.fragments.ReceiptFragment
import hr.foi.air.breadr.fragments.ScanFragment
import hr.foi.air.core.ScanOptionPresenter


object OptionPresenterManager {
    //    keep evidence on module
    private val modules = ArrayList<ScanOptionPresenter>()

    init {
        modules.add(ScanFragment())
    }

    //    keep evidence on currently active modules
    private lateinit var currentModule: ScanOptionPresenter

    //    dynamically create drawer menu (or other navigation)
    private lateinit var activity: AppCompatActivity
    private lateinit var binding: ActivityMainBinding

    fun setDependencies(binding: ActivityMainBinding, activity: AppCompatActivity) {
        this.binding = binding
        this.activity = activity
        setupScanOptions()
    }

    private fun setupScanOptions() {
        modules.forEach {   module ->
            val button = Button(activity)
            button.layoutParams = LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.WRAP_CONTENT,
                LinearLayout.LayoutParams.WRAP_CONTENT
            )
            button.text = module.getName(activity)
            button.setPadding(20,10,20,10)
            // icon
            button.setCompoundDrawablesWithIntrinsicBounds(module.getIcon(activity), null,null,null)
            // background color and border radius
            button.setBackgroundResource(R.drawable.layout_round)
            val drawable = button.background
            drawable.setColorFilter(Color.GRAY, PorterDuff.Mode.SRC)
            button.setOnClickListener {
                startModule(module)}
            // add Button to LinearLayout
            binding.nvScanOptions.addView(button)
        }
    }

    private fun startModule(module : ScanOptionPresenter)
    {
        currentModule = module

        val intent = Intent(activity, PurchaseActivity::class.java)
        if(activity::class == MainActivity::class)
        {
            PurchaseActivity.targetFragment = module.getFragment()//
        }
        activity.startActivity(intent)
    }


//    private fun loadDataToModule(module: ScanOptionPresenter) {
//        DataRepository().loadData(activity, module.getDataListener())
//    }


//    change active modules
//    make sure that active module receives a data

//    fun startMainModule()
//    {
//        val mainModule = modules.get(0)
//        startModule(mainModule)
//    }

}
