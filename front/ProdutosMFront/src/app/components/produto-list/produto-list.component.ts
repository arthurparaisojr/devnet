import { Component, OnInit } from '@angular/core';
import { ProdutoService, Produto } from '../../services/produto.service';

@Component({
  selector: 'app-produto-list',
  templateUrl: './produto-list.component.html',
  styleUrls: ['./produto-list.component.css']
})
export class ProdutoListComponent implements OnInit {
  produtos: Produto[] = [];

  constructor(private produtoService: ProdutoService) {}

  ngOnInit(): void {
    this.produtoService.getProdutos().subscribe((data) => {
      this.produtos = data;
    });
  }
}
