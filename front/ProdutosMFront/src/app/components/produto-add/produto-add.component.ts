import { Component } from '@angular/core';
import { ProdutoService, Produto } from '../../services/produto.service';

@Component({
  selector: 'app-produto-add',
  templateUrl: './produto-add.component.html',
  styleUrls: ['./produto-add.component.css']
})
export class ProdutoAddComponent {
  novoProduto: Produto = {
    id: 0,
    nome: '',
    preco: 0,
    quantidade: 0
  };

  constructor(private produtoService: ProdutoService) {}

  adicionarProduto(): void {
    this.produtoService.addProduto(this.novoProduto).subscribe(() => {
      alert('Produto adicionado com sucesso!');
      this.novoProduto = { id: 0, nome: '', preco: 0, quantidade: 0 };
    });
  }
}
