import { Label } from '@gravity-ui/uikit'

import { ICategory } from '~models/category'

interface CategoryCardProps {
	category: ICategory
}

export function CategoryCard({ category }: CategoryCardProps) {
	return (
		<Label size={'m'} theme={'clear'} interactive={false}>
			{category.title}
		</Label>
	)
}
