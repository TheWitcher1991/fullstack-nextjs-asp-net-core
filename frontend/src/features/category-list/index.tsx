import { CategoryCard, ICategory } from '~models/category'

interface CategoryListProps {
	categories: ICategory[]
}

export default function CategoryList({ categories }: CategoryListProps) {
	return categories.map(category => (
		<CategoryCard key={category.id} category={category} />
	))
}
