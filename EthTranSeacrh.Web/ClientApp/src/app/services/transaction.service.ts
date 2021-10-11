import { Injectable } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ITransactionQueryViewModel } from '../models/transaction-query.model';
import { ITransactionViewModel } from "../models/transaction.model";

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public findTransactions(blockNumber: number, address: string) {

    let search = <ITransactionQueryViewModel>{ address: address, blockNumber: blockNumber };
    return this.http.post<ITransactionViewModel[]>(this.baseUrl + 'transaction', search);
  }
}
