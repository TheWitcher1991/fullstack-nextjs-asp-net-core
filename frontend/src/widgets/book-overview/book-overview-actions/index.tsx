import { Ellipsis } from '@gravity-ui/icons'
import { Button, Flex, Icon } from '@gravity-ui/uikit'

import BookOFavoriteButton from '~features/book-favorite-button'

import { IBook } from '~models/book'

import { staticPath } from '~packages/utils'

interface BookOverviewProps {
	book: IBook
}

const buttonStyle = {
	borderRadius: 99,
	overflow: 'hidden',
}

export default function BookOverviewActions({ book }: BookOverviewProps) {
	const onRead = () => {
		window.open(staticPath(book.filePath), '_blank')
	}

	return (
		<Flex gap={3}>
			<Button
				size={'xl'}
				view={'action'}
				style={buttonStyle}
				onClick={onRead}
			>
				Читать
			</Button>
			<BookOFavoriteButton book={book} />
			<Button
				size={'xl'}
				onlyIcon={true}
				disabled={true}
				style={buttonStyle}
			>
				<Icon data={Ellipsis} size={18} />
			</Button>
		</Flex>
	)
}
