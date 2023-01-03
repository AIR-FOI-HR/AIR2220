package hr.foi.air.breadr

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.fragment.app.Fragment
import hr.foi.air.breadr.databinding.ActivityMainBinding
import hr.foi.air.breadr.managers.OptionPresenterManager


class MainActivity : AppCompatActivity() {

    private var currentFragment : Fragment? = null
    private lateinit var binding : ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        binding = ActivityMainBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)
//                initializeLayout()
        //        showMainFragment()
        //        loadDataToFragment()

//        navigateToTestFragment()

        //        initialize manager
        OptionPresenterManager.setDependencies(binding, this)
//        DataPresenterManager.startMainModule()

    }

//    private fun navigateToTestFragment() {
//        this.supportFragmentManager.beginTransaction()
//            .replace(binding.layoutMain.contentMain.mainFragment.id, module.getFragment())
//            .commit()
//
//    }

//    private fun initializeLayout()
//    {
//
//    }


}