import { Flex } from '@gravity-ui/uikit'

import BooksSearchInput from '~widgets/books-search/books-search-input'
import BooksSearchList from '~widgets/books-search/books-search-list'

import BookSkeletonList from '~features/book-skeleton-list/index.tsx'

import { Spacing } from '~packages/ui'

export default function BooksSearch() {
	return (
		<div>
			<BooksSearchInput />
			<Spacing />
			<Flex gap={2} direction={'column'}>
				<BookSkeletonList count={3} />
				<BooksSearchList />
			</Flex>
		</div>
	)
}
