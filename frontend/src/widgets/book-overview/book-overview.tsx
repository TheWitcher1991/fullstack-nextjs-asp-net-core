import { Flex, Text } from '@gravity-ui/uikit'
import { PropsWithChildren } from 'react'

import BookOverviewActions from '~widgets/book-overview/book-overview-actions'

import BookTabs from '~features/book-tabs'

import { IBook } from '~models/book'

import { CardImage, Spacing } from '~packages/ui'
import { staticPath, trimText } from '~packages/utils'

interface BookOverviewProps extends PropsWithChildren {
	book: IBook
}

export default function BookOverview({ book, children }: BookOverviewProps) {
	return (
		<>
			<Flex gap={6}>
				<CardImage
					height={290}
					width={189}
					src={staticPath(book.imagePath)}
				/>
				<Flex direction={'column'}>
					<Text variant={'body-3'} color={'secondary'}>
						{book.author.fullName}
					</Text>
					<Spacing v={'xss'} />
					<Text variant={'display-1'}>{book.title}</Text>
					<Spacing v={'s'} />
					<BookOverviewActions book={book} />
					<Spacing />
					<BookTabs book={book} />
					<Spacing />
					{children}
				</Flex>
			</Flex>
		</>
	)
}
