package hr.foi.air.breadr

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.fragment.app.Fragment
import hr.foi.air.breadr.databinding.ActivityPurchaseBinding
import hr.foi.air.breadr.fragments.BuyFragment


class PurchaseActivity : AppCompatActivity() {
    private var currentFragment : Fragment? = null
    private lateinit var binding : ActivityPurchaseBinding


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_purchase)

        binding = ActivityPurchaseBinding.inflate(layoutInflater)

        this.supportFragmentManager.beginTransaction()
            .replace(binding.fcvPurchase.id, targetFragment)
            .commit()

    }

    companion object{
        var targetFragment: Fragment = Fragment()
    }
}