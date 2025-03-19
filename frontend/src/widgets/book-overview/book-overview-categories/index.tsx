import { Flex, Text } from '@gravity-ui/uikit'

import CategoryList from '~features/category-list'

import { IBook } from '~models/book'

interface BookOverviewCategoriesProps {
	book: IBook
}

export default function BookOverviewCategories({
	book,
}: BookOverviewCategoriesProps) {
	return (
		<Flex gap={2} wrap={'wrap'}>
			<CategoryList categories={book.categories} />
		</Flex>
	)
}
