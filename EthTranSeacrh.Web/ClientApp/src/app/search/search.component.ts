import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ITransactionViewModel } from "../models/transaction.model";
import { ITransactionQueryViewModel } from "../models/transaction-query.model";
import { TransactionService } from "../services/transaction.service";
import { AlertService } from '../tools/alert';

@Component({
  selector: 'search',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public transactions: ITransactionViewModel[];
  public blockNumber: number;
  public address: string;
  public isWorking: boolean;

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private transactionService: TransactionService,
    protected alertService: AlertService) {

  }

  public find() {
    this.isWorking = true;
    if (this.blockNumber && this.address) {
      this.transactionService.findTransactions(this.blockNumber, this.address).subscribe(result => {
          this.isWorking = false;
          this.transactions = result;
        },
        error => console.error(error));
    } else {
      this.isWorking = false;
      this.alertService.alert(new alert("please provide the search details!"));
    }
  }
}


