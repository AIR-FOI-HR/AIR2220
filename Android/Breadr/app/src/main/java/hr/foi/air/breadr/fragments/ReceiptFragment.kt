package hr.foi.air.breadr.fragments

import android.content.Intent
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import hr.foi.air.breadr.MainActivity
import hr.foi.air.breadr.data.DataRepository
import hr.foi.air.breadr.databinding.ActivityMainBinding.inflate
import hr.foi.air.breadr.databinding.FragmentBuyBinding
import hr.foi.air.breadr.databinding.FragmentReceiptBinding
import hr.foi.air.core.LoadDataPurchaseListener
import hr.foi.air.core.entities.Receipt


class ReceiptFragment(gateId: Int, userId: Int) : Fragment(), LoadDataPurchaseListener {
    private var gateId: Int
    private var userId: Int
    private lateinit var receipt: Receipt
    private lateinit var binding: FragmentReceiptBinding
    private var receiptLoadedFlag: Boolean = false
    private var viewReadyFlag: Boolean = false
    private var dataPurchaseListener: LoadDataPurchaseListener = this

    init {
        this.gateId = gateId
        this.userId = userId
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        viewReadyFlag =  true
        // linking button:
        binding.btnReturn.setOnClickListener{ goHome() }
        // displaying data:
        tryToDisplayData()
        super.onViewCreated(view, savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // load data (make the payment and create receipt)
        buyProduct()
        // setup binding
        binding = FragmentReceiptBinding.inflate(inflater, container, false)
        return binding.root
    }

    private fun buyProduct() {
        DataRepository().loadPurchase(this.requireContext(), dataPurchaseListener, gateId, userId)
    }

    override fun onPurchaseLoaded(receipt: Receipt) {
        this.receipt = receipt
        receiptLoadedFlag = true
        tryToDisplayData()
    }

    private fun goHome() {
        val intent = Intent(activity, MainActivity::class.java)
        activity?.startActivity(intent)
    }

    private fun tryToDisplayData() {
        if (receiptLoadedFlag && viewReadyFlag)
        {
            binding.tvReceiptPrice.text = receipt.price.toString()
            binding.tvReceiptName.text = receipt.name
        }
    }
}