import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocalizePipe } from '@shared/pipes/localize.pipe';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ProductServiceProxy, ProductDto } from '@shared/service-proxies/service-proxies';

@Component({
  standalone: true,
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
  imports: [CommonModule, LocalizePipe, ReactiveFormsModule]
})
export class ProductsComponent implements OnInit {
  products: any[] = [];
  productForm: FormGroup;
  isEditing = false;
  currentProductId: string | null = null;

  constructor(
    private productService: ProductServiceProxy,
    private fb: FormBuilder
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
    });
  }
  ngOnInit(): void {
    this.getAll();
  }
  getAll(): void {
    const sorting = '';
    const skipCount = 0;
    const maxResultCount = 100;
    this.productService.getAll(sorting, skipCount, maxResultCount).subscribe({
      next: (result) => {
        if (result && result.items) {
          this.products = result.items;
          console.log('Products loaded:', this.products);
        } else {
          console.warn('No products returned');
          this.products = [];
        }
      },
      error: (error) => {
        console.error('Failed to fetch products:', error);
        const errorMsg = error?.error?.message || 'An unexpected error occurred.';
        alert('Product loading failed: ' + errorMsg);
      }
    });
  }
  deleteProduct(id: string): void {
    if (confirm('Are you sure you want to delete this product?')) {
      const numericId = Number(id);
      this.productService.delete(numericId).subscribe({
        next: () => {
          console.log('Product deleted successfully');
          this.getAll();
          alert('Product deleted successfully!');
        },
        error: (error) => {
          console.error('Failed to delete product:', error);
          const errorMsg = error?.error?.message || 'An unexpected error occurred.';
          alert('Product deletion failed: ' + errorMsg);
        }
      });
    }
  }
  editProduct(product: any): void {
    this.productForm.patchValue({
      name: product.name,
      price: product.price
    });

    this.currentProductId = product.id.toString();
    this.isEditing = true;
  }

 saveProduct(): void {
  debugger;
  if (this.productForm.invalid) {
    alert('Please fill in all required fields');
    return;
  }

  const formValues = this.productForm.value;

  if (this.isEditing && this.currentProductId) {
    const updatedProduct = new ProductDto({
      id: Number(this.currentProductId),
      name: String(formValues.name),
      price: Number(formValues.price)
    });

    this.productService.update(updatedProduct).subscribe({
      next: () => {
        alert('Product updated!');
        this.getAll();
        this.resetForm();
      },
      error: (error) => {
        console.error('Error:', error);
        const errorMsg = error.error?.error?.message || error.message || 'Server error';
        alert(`Update failed: ${errorMsg}`);
      }
    });
  } else {
    // 👇 Create new product (added block)
    const newProduct: any = {
      name: String(formValues.name),
      price: Number(formValues.price)
    };

    this.productService.create(newProduct).subscribe({
      next: () => {
        alert('Product created!');
        this.getAll();
        this.resetForm();
      },
      error: (error) => {
        console.error('Creation error:', error);
        const errorMsg = error?.error?.message || 'An error occurred during creation.';
        alert(`Create failed: ${errorMsg}`);
      }
    });
  }
}

  resetForm(): void {
    this.productForm.reset();
    this.currentProductId = null;
    this.isEditing = false;
  }
}
