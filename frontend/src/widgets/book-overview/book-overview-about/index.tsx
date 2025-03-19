import { Text } from '@gravity-ui/uikit'

import { IBook } from '~models/book'

interface BookOverviewAboutProps {
	book: IBook
}

export default function BookOverviewAbout({ book }: BookOverviewAboutProps) {
	return <Text variant={'body-2'}>{book.description}</Text>
}
