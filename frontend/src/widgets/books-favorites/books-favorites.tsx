import { Flex } from '@gravity-ui/uikit'

import BookSkeletonList from '~features/book-skeleton-list/index.tsx'

export default function BooksFavorites() {
	return (
		<Flex gap={2} direction={'column'}>
			<BookSkeletonList count={10} />
		</Flex>
	)
}
